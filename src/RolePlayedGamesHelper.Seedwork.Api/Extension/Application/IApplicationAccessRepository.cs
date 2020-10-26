namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Application
{
    /// <summary>
    /// The ApplicationAccessRepository interface.
    /// </summary>
    public interface IApplicationAccessRepository
    {
        /// <summary>
        /// Checks if the API key is valid
        /// </summary>
        /// <param name="apiKey">The API key to check</param>
        /// <returns>true if key is valid</returns>
        bool CheckValidApiKey(string apiKey);
    }
}