using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Swagger
{
    /// <summary>
    /// The swagger extension.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Gets the xml comments file path.
        /// </summary>
        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        /// <summary>
        /// The add swagger documentation.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
           
            services.AddSwaggerGen(
                options =>
                {
                    using (var serviceProvider = services.BuildServiceProvider())
                    {
                        var provider = serviceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerDoc(
                                description.GroupName,
                                new OpenApiInfo
                                {
                                    Title = $"Gomel Gurps API {description.ApiVersion}",
                                    Version = description.ApiVersion.ToString()
                                });
                        }
                    }

                    // options.OperationFilter<FileUploadOperation>();
                    options.OperationFilter<VersionFilter>();

                    // options.OperationFilter<SwaggerDefaultValues>();
                    options.DocumentFilter<SecurityRequirementsDocumentFilter>();
                    options.DocumentFilter<VersionFilter>();
                  //  options.IncludeXmlComments(@"GurpsAssistant.ItemsService.Api.xml"/*XmlCommentsFilePath*/);

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
        }

        /*   /// <summary>
           /// The create info for api version.
           /// </summary>
           /// <param name="description">
           /// The description.
           /// </param>
           /// <returns>
           /// The <see cref="Info"/>.
           /// </returns>
           private static Info CreateInfoForApiVersion(ApiVersionDescription description)
           {
               var info = new Info()
               {
                   Title = $"Sample API {description.ApiVersion}",
                   Version = description.ApiVersion.ToString(),
                   Description = "A Super Ticket Api Endpoint with Swagger, Swashbuckle, and API versioning.",
                   Contact = new Contact() { Name = "Siarhei Linkevich", Email = "mrtaler@me.com" },
                   TermsOfService = "Shareware",
                   License = new License() { Name = "MIT", Url = "https://opensource.org/licenses/MIT" }
               };

               if (description.IsDeprecated)
               {
                   info.Description += " This API version has been deprecated.";
               }

               return info;
           }*/
    }
}