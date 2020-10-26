namespace RolePlayedGamesHelper.Seedwork.Api.Extension.Config
{
    /// <summary>
    /// The correlation id options.
    /// </summary>
    public class CorrelationIdOptions
    {
        /// <summary>
        /// The header field name where the correlation ID will be stored
        /// </summary>
        public string Header { get; set; } = "correlationId";
    }
}