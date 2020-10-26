using System.Net;
using System.Threading.Tasks;
using GurpsAssistant.Seedwork.Api;
using Microsoft.AspNetCore.Http;
using RolePlayedGamesHelper.Seedwork.Api.ErrorHandling;
using RolePlayedGamesHelper.Seedwork.Api.Extension.Application;
using Serilog;

namespace RolePlayedGamesHelper.Seedwork.Api.Middlewares
{
    /// <summary>
    /// A middleware for rejecting responses with missing or incorrect API Key
    /// </summary>
    public class ApiKeyMiddleware
    {
        /// <summary>
        /// The api key header name.
        /// </summary>
        private const string ApiKeyHeaderName = "x-api-key";

        /// <summary>
        /// The next.
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// The repo.
        /// </summary>
        private readonly IApplicationAccessRepository repo;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyMiddleware"/> class.
        /// </summary>
        /// <param name="next">
        /// The next.
        /// </param>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ApiKeyMiddleware(RequestDelegate next, IApplicationAccessRepository repo, ILogger logger)
        {
            this.next = next;
            this.repo = repo;
            this.logger = logger;
        }

        /// <summary>
        /// Invoke the middleware
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains(ApiKeyHeaderName))
            {
                var error = new ApiError("API Key is missing");
                logger.ApiError(error);
                return context.WriteErrorAsync(error, HttpStatusCode.Forbidden);
            }

            if (!repo.CheckValidApiKey(context.Request.Headers[ApiKeyHeaderName]))
            {
                var error = new ApiError("Invalid API Key");
                logger.ApiError(error);
                return context.WriteErrorAsync(error, HttpStatusCode.Unauthorized);
            }

            return next.Invoke(context);
        }
    }
}
