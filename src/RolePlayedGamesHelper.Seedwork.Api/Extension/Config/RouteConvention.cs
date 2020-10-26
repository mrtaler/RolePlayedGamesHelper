using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Config
{
    /// <summary>
    /// The route convention.
    /// </summary>
    public class RouteConvention : IApplicationModelConvention
    {
        /// <summary>
        /// The central prefix.
        /// </summary>
        private readonly AttributeRouteModel routePrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteConvention"/> class.
        /// </summary>
        /// <param name="route">
        /// The route.
        /// </param>
        public RouteConvention(IRouteTemplateProvider route)
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
            foreach (var controller in application.Controllers)
            {
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                            routePrefix,
                            selectorModel.AttributeRouteModel);
                    }
                }

                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();

                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = routePrefix;
                    }
                }
            }
        }
    }
}