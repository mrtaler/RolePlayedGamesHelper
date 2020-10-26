using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Swagger
{
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
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "CorrelationId"}
                        },
                        Array.Empty<string>()
                    }
                }
            };
        }
    }
}