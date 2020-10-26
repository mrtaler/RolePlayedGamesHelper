using System.Collections.Generic;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Config
{
    /// <summary>
    /// The api key access settings.
    /// </summary>
    public class ApiKeyAccessSettings
    {
        /// <summary>
        /// The list of keys that will be accepted
        /// </summary>
        public List<string> ValidKeys { get; set; }
    }
}
