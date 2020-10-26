using System;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Swagger
{
    /// <summary>
    /// The swagger default values.
    /// </summary>
    internal class SwaggerDefaultValues : IOperationFilter
    {
        /// <summary>
        /// The apply.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/412
            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/413
            var tm = operation.Parameters.Where(x => x.In == ParameterLocation.Path || x.In == ParameterLocation.Query);

            foreach (var parameter in tm)
            {
                var description = context.ApiDescription.ParameterDescriptions
                    .First(p => string
                        .Equals(p.Name, parameter.Name, StringComparison.CurrentCultureIgnoreCase));

                var routeInfo = description.RouteInfo;

                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                if (routeInfo == null)
                {
                    continue;
                }
                /*if (parameter.Schema.Default == null)
                              {
                                  parameter.Schema.Default =new OpenApiAnyFactory. routeInfo.DefaultValue;
                              }
                              */
                parameter.Required |= !routeInfo.IsOptional;
            }
        }
    }
}