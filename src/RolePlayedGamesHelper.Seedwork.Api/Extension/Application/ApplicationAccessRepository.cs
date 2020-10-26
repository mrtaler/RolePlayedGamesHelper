using Microsoft.Extensions.Options;
using RolePlayedGamesHelper.Seedwork.Api.Extension.Config;

namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Application
{
    /// <summary>
    /// The application access repository.
    /// </summary>
    internal class ApplicationAccessRepository : IApplicationAccessRepository
    {
        /// <summary>
        /// The options.
        /// </summary>
        private readonly IOptions<ApiKeyAccessSettings> options;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationAccessRepository"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public ApplicationAccessRepository(IOptions<ApiKeyAccessSettings> options)
        {
            this.options = options;
        }

        /// <inheritdoc />
        public bool CheckValidApiKey(string apiKey)
        {
            return options.Value.ValidKeys.Contains(apiKey);
        }
    }
}