using System;
using System.Collections.Generic;
using Autofac;
using AutofacSerilogIntegration;
using GurpsAssistant.Seedwork.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RolePlayedGamesHelper.Cqrs.EventSourcing;
using RolePlayedGamesHelper.Cqrs.Kledex.Bus.ServiceBus;
using RolePlayedGamesHelper.Cqrs.Kledex.Domain;
using RolePlayedGamesHelper.Cqrs.Kledex.Extensions;
using RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities;
using RolePlayedGamesHelper.Cqrs.Kledex.Store.EF.Entities.Factories;
using RolePlayedGamesHelper.Cqrs.Kledex.Store.RavenDb;
using RolePlayedGamesHelper.GatalogService.Domain;
using RolePlayedGamesHelper.GatalogService.Services.WeaponService.Queries;
using RolePlayedGamesHelper.Seedwork.Api.Extension.Config;
using RolePlayedGamesHelper.Seedwork.Api.Extension.Swagger;
using RolePlayedGamesHelper.Seedwork.Api.ServiceDomain;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using ILogger = Serilog.ILogger;

namespace RolePlayedGamesHelper.GatalogService.Api
{
  public class Startup
  {
    /// <summary>
    /// The environment.
    /// </summary>
    private readonly IWebHostEnvironment environment;

    /// <summary>
    /// The _configuration.
    /// </summary>
    private readonly IConfigurationRoot configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="Startup"/> class.
    /// </summary>
    /// <param name="env">
    /// The env.
    /// </param>
    public Startup(IWebHostEnvironment env)
    {
      environment = env;
      configuration = new ConfigurationBuilder()
                      .SetBasePath(env.ContentRootPath)
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables()
                      .Build();
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddOptions();
      services.AddSwaggerGen(
        options =>
        {
          options.DocumentFilter<SecurityRequirementsDocumentFilter>();
          options.AddSecurityDefinition(
            "ApiSecurity",
            new OpenApiSecurityScheme
            {
              Name = "x-api-key",
              In = ParameterLocation.Header,
              Type = SecuritySchemeType.ApiKey
            });

          options.AddSecurityDefinition(
            "CorrelationId",
            new OpenApiSecurityScheme
            {
              Name = "correlationId",
              In = ParameterLocation.Header,
              Type = SecuritySchemeType.ApiKey
            });
          options.DescribeAllParametersInCamelCase();
        });
      services.Configure<AzureTablesEventSourcingOptions>(x
                                                            => new AzureTablesEventSourcingOptions
                                                            {
                                                              TableName = "eventstore",
                                                              StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=gurpsassistantdiag;AccountKey=cR55mn5c8OPyUWlNa972/Zr7ExWmFJZu7rWNfUf4ylDCCaalsOtGS5MGoqDCuFGBF93mHXWyOCb8TcWzUwASrw==;EndpointSuffix=core.windows.net"
                                                            });
      services.SetupApiKeyAccessSettings(configuration);
      services.SetupCorrelationIdOptions(configuration);
      services.AddRouting(options => options.LowercaseUrls = true);
      // services.InitializeApplicationInsights("ItemsService");
      services.AddControllers(o
                                =>
                              {
                                // o.UseGeneralRoutePrefix("api/v{version:apiVersion}");
                                o.UseGeneralRoutePrefix("api");
                              })
              .AddNewtonsoftJson(options =>
              {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
              });
      services.AddKledex(
                options =>
                {
                  options.PublishEvents = true;
                  options.SaveCommandData = true;
                  options.ValidateCommands = false;
                  options.CacheTime = 600;
                },
                typeof(GetWeaponById),
                typeof(ServiceDomainEvent))
              .AddServiceBusProvider()
              .AddRavenDbDataProvider(o => new DomainDbOptions())
              .AddServiceBusProvider();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
      ServerExtension.InitializeLogger(environment, "ItemsService");
      builder.RegisterLogger(Log.Logger);

      builder.RegisterType<EventEntityFactory>().As<IEventEntityFactory>();

      builder.InitializeApplicationAccessRepository();
      builder.RegisterModule(new ItemsServiceDalModule(true));
      builder.RegisterModule(new GurpsAssistantSeedworkEventSourcingModule());
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(
      IApplicationBuilder app,
      ILogger logger)
    {
      if (!environment.IsProduction())
      {
        ServerExtension.LogConfiguration(logger, environment, configuration);
      }

      var option = new RewriteOptions();
      option.AddRedirect("^$", "swagger");
      app.UseRewriter(option);

      app.UseRouting();
      app.UseStaticFiles();
      app.UseDefaultFiles();

      app.UseCors(
        c =>
        {
          c.AllowAnyHeader();
          c.AllowAnyMethod();
          c.AllowAnyOrigin();
        });

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });



      //  app.UseCorrelationId();
      //  app.UseApiKey();
      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

    }
  }
  /// <summary>
  /// The security requirements document filter.
  /// </summary>
  internal class SecurityRequirementsDocumentFilter : IDocumentFilter
  {
    /// <summary>
    /// The apply.
    /// </summary>
    /// <param name="swaggerDoc">
    /// The swagger doc.
    /// </param>
    /// <param name="context">
    /// The context.
    /// </param>
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
      swaggerDoc.SecurityRequirements = new List<OpenApiSecurityRequirement>
      {
        /*{
            new OpenApiSecurityRequirement
            {{

                new[]   { "ApiSecurity", Array.Empty<string>() },
                new[]  { "CorrelationId", Array.Empty<string>() },
           } }
        };*/
              
        // swaggerDoc.SecurityRequirements.Add(
        new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "ApiSecurity"}
            },
            Array.Empty<string>()
          }
        },
        new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "correlationId"}
            },
            Array.Empty<string>()
          }
        }
      };
    }
  }
}
