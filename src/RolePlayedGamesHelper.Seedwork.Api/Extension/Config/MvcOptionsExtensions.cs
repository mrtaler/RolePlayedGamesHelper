using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Config
{
    /// <summary>
    /// The mvc options extensions.
    /// </summary>
    public static class MvcOptionsExtensions
    {
        /// <summary>
        /// The use general route prefix.
        /// </summary>
        /// <param name="opts">
        /// The opts.
        /// </param>
        /// <param name="routeAttribute">
        /// The route attribute.
        /// </param>
        public static void UseGeneralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
        {
            opts.Conventions.Add(new RoutePrefixConvention(routeAttribute));
        }

        /// <summary>
        /// The use general route prefix.
        /// </summary>
        /// <param name="opts">
        /// The opts.
        /// </param>
        /// <param name="prefix">
        /// The prefix.
        /// </param>
        public static void UseGeneralRoutePrefix(this MvcOptions opts, string prefix)
        {
            opts.UseGeneralRoutePrefix(new RouteAttribute(prefix));
        }
    }
}