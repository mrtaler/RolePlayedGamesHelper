﻿namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Swagger
{
   /* internal class FileUploadOperation : IOperationFilter
    {
        /// <summary>
        /// The form file property names.
        /// </summary>
        private static readonly string[] FormFilePropertyNames =
            typeof(IFormFile).GetTypeInfo().DeclaredProperties.Select(p => p.Name).ToArray();

        /// <inheritdoc />
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = operation.Parameters;
            if (parameters == null || parameters.Count == 0)
            {
                return;
            }

            var formFileParameterNames = new List<string>();
            var formFileSubParameterNames = new List<string>();

            foreach (var actionParameter in context.ApiDescription.ActionDescriptor.Parameters)
            {
                var properties =
                    actionParameter.ParameterType.GetProperties()
                        .Where(p => p.PropertyType == typeof(IFormFile))
                        .Select(p => p.Name)
                        .ToArray();

                if (properties.Length != 0)
                {
                    formFileParameterNames.AddRange(properties);
                    formFileSubParameterNames.AddRange(properties);
                    continue;
                }

                if (actionParameter.ParameterType != typeof(IFormFile))
                {
                    continue;
                }

                formFileParameterNames.Add(actionParameter.Name);
            }

            if (!formFileParameterNames.Any())
            {
                return;
            }

            var consumes = operation.Consumes;
            consumes.Clear();
            consumes.Add("multipart/form-data");

            foreach (var parameter in parameters.ToArray())
            {
                if (!(parameter is NonBodyParameter) || parameter.In != "formData")
                {
                    continue;
                }

                if (formFileSubParameterNames.Any(p => parameter.Name.StartsWith(p + "."))
                    || FormFilePropertyNames.Contains(parameter.Name))
                {
                    parameters.Remove(parameter);
                }
            }

            foreach (var formFileParameter in formFileParameterNames)
            {
                var param = parameters.First(p => p.Name.ToUpper() == formFileParameter.ToUpper());
                parameters.Remove(param);
                parameters.Add(new NonBodyParameter()
                {
                    Name = formFileParameter,
                    Type = "file",
                    In = "formData"
                });
            }

            var uploadParametr = operation.Parameters.FirstOrDefault(p => p.Name.Contains("File"));
            //  var uploadParametr = operation.Parameters.FirstOrDefault(p => p.Name.Contains("uploadedFile"));
            if (uploadParametr != null)
            {
                operation.Parameters.Remove(uploadParametr);
                operation.Parameters.Add(new OpenApiParameter
                {
                    Schema = new OpenApiSchema { Type = "file" },
                    In = ParameterLocation,
                    Required = true,
                    Name = "uploadedFile",
                    Description = uploadParametr.Description

                });
                // operation.Consumes.Add("application/form-data");
                operation.Consumes.Add("multipart/form-data");
            }
           
        }
    }*/
}
