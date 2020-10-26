using System;
using System.Linq;
using Autofac;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RolePlayedGamesHelper.Seedwork.Api.Extension.Application;
using RolePlayedGamesHelper.Seedwork.Api.Extension.Config;
using RolePlayedGamesHelper.Seedwork.Api.Middlewares;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace GurpsAssistant.Seedwork.Api
{
    /// <summary>
    /// The server extension.
    /// </summary>
    public static class ServerExtension
    {
        /// <summary>
        /// The initialize logger (Serilog).
        /// </summary>
        /// <param name="env">
        /// The env.
        /// </param>
        /// <param name="moduleName">
        /// The module Name.
        /// </param>
        public static void InitializeLogger(
            IHostEnvironment env,
            string moduleName)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .Enrich.WithOperationId()
                .Enrich.WithProcessId()
                .Enrich.WithProperty("Environment", env.EnvironmentName)
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                /*.WriteTo.RollingFile(
                    pathFormat: "c:\\Logs\\" + moduleName + "-Log-{Date}.txt",
                    restrictedToMinimumLevel: LogEventLevel.Debug)*/

                // outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ffff}|{TenantName}|{RequestId}|{SourceContext}|{Level:u3}|{Message:lj}{NewLine}{Exception}")
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)

                // , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ffff}|{TenantName}|{RequestId}|{SourceContext}|{Level:u3}|{Message:lj}{NewLine}{Exception}")
                .WriteTo.ApplicationInsights(
                     "f4f805f1-20e5-4605-88ba-dfcd17984b79",
                     TelemetryConverter.Traces,
                     LogEventLevel.Information)
                .CreateLogger();
            Log.Information("The global logger has been configured.");
            Log.Information("Hello, Serilog!");
        }

        /// <summary>
        /// The log configuration.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public static void LogConfiguration(
                 ILogger logger,
                 IHostEnvironment env,
                 IConfigurationRoot configuration)
        {
            logger.Information(
                "Using environment: {Environment}",
                env.EnvironmentName);
            logger.Debug(
                "Using configuration: {NewLine:l}{Configuration:l}",
                Environment.NewLine,
                string.Join(Environment.NewLine, configuration.AsEnumerable().Select(conf => $"{conf.Key} = {conf.Value}")));
        }

        /// <summary>
        /// The initialize application insights.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="apiName">
        /// The api name.
        /// </param>
        public static void InitializeApplicationInsights(this IServiceCollection services, string apiName)
        {
            services.AddWebEncoders();
            services.AddSingleton<ITelemetryInitializer>(new LoggingInitializer(apiName));
            services.AddApplicationInsightsTelemetry(options =>
            {
                options.EnableDebugLogger = false;
            });
        }

        /// <summary>
        /// The with operation id.
        /// </summary>
        /// <param name="enrichConfiguration">
        /// The enrich configuration.
        /// </param>
        /// <returns>
        /// The <see cref="LoggerConfiguration"/>Logger configuration
        /// </returns>
        /// <exception cref="ArgumentNullException"> if null
        /// </exception>
        public static LoggerConfiguration WithOperationId(this LoggerEnrichmentConfiguration enrichConfiguration)
        {
            if (enrichConfiguration is null)
            {
                throw new ArgumentNullException(nameof(enrichConfiguration));
            }

            return enrichConfiguration.With<OperationIdEnricher>();
        }


        public static void InitializeApplicationAccessRepository(this ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationAccessRepository>().As<IApplicationAccessRepository>().SingleInstance();
        }

        public static void SetupApiKeyAccessSettings(this IServiceCollection services, IConfigurationRoot configuration)
        {
             services.Configure<ApiKeyAccessSettings>(configuration.GetSection("ApiKeys"));
        }

        public static void SetupCorrelationIdOptions(this IServiceCollection services, IConfigurationRoot configuration)
        {
             services.Configure<CorrelationIdOptions>(configuration.GetSection("CorrelationId"));
        }

        /// <summary>
        /// Enable ApiKeyValidation middleware
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <returns>
        /// The <see cref="IApplicationBuilder"/>.
        /// </returns>
        public static IApplicationBuilder UseApiKey(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiKeyMiddleware>();
            return app;
        }

        /// <summary>
        /// Enable CorrelationIdValidation middleware
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <returns>
        /// The <see cref="IApplicationBuilder"/>.
        /// </returns>
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        {
            app.UseMiddleware<CorrelationIdMiddleware>();
            return app;
        }
    }
}
