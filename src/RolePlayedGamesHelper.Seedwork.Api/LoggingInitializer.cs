using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace RolePlayedGamesHelper.Seedwork.Api
{
    /// <summary>
    /// The logging initializer.
    /// </summary>
    public class LoggingInitializer : ITelemetryInitializer
    {
        /// <summary>
        /// The _role name.
        /// </summary>
        private readonly string roleName;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingInitializer"/> class.
        /// </summary>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        public LoggingInitializer(string roleName = null)
        {
            this.roleName = roleName ?? "api";
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="telemetry">
        /// The telemetry.
        /// </param>
        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Cloud.RoleName = roleName;
        }
    }
}