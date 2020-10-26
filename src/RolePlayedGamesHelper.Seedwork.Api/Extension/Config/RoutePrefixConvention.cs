using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Config
{
    /// <summary>
    /// The route prefix convention.
    /// </summary>
    public class RoutePrefixConvention : IApplicationModelConvention
    {
        /// <summary>
        /// The _route prefix.
        /// </summary>
        private readonly AttributeRouteModel routePrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoutePrefixConvention"/> class.
        /// </summary>
        /// <param name="route">
        /// The route.
        /// </param>
        public RoutePrefixConvention(IRouteTemplateProvider route)
        {
            routePrefix = new AttributeRouteModel(route);
        }

        /// <summary>
        /// The apply.
        /// </summary>
        /// <param name="application">
        /// The application.
        /// </param>
        public void Apply(ApplicationModel application)
        {
            foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
            {
                selector.AttributeRouteModel = selector.AttributeRouteModel != null 
                    ? AttributeRouteModel.CombineAttributeRouteModel(routePrefix, selector.AttributeRouteModel) 
                    : routePrefix;
            }
        }
    }
}