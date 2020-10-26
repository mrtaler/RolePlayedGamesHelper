using System;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Swagger
{
    /// <summary>
    /// The version filter.
    /// </summary>
    internal class VersionFilter : IDocumentFilter, IOperationFilter
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
         /*   var versionParameter = operation.Parameters?.First(p => p.Name == "version" || p.Name == "api-version");
            operation.Parameters?.Remove(versionParameter);*/
        }

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
            var parts = swaggerDoc.Paths
                .Select(
                    kvp =>
                    {
                        var newPath = kvp.Key.Replace(
                            "{api-version}",
                            swaggerDoc.Info.Version,
                            StringComparison.Ordinal);

                        // return KeyValuePair.Create(newPath, pathItem);
                        return (newPath, kvp.Value);
                    }).ToList();
            var tm = new OpenApiPaths();
            parts.ForEach(x => tm.Add(x.newPath, x.Value));
            swaggerDoc.Paths = tm;
        }
    }
}