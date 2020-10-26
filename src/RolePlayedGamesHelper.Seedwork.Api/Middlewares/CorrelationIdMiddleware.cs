using System;
using System.Threading.Tasks;
using GurpsAssistant.Seedwork.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RolePlayedGamesHelper.Seedwork.Api.ErrorHandling;
using RolePlayedGamesHelper.Seedwork.Api.Extension.Config;
using Serilog;
using Serilog.Context;
using Serilog.Events;

namespace RolePlayedGamesHelper.Seedwork.Api.Middlewares
{
    /// <summary>
    /// A middleware for rejecting requests with correlation ID missing.
    /// </summary>
    internal class CorrelationIdMiddleware
    {
        /// <summary>
        /// The _next.
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// The _options.
        /// </summary>
        private readonly IOptions<CorrelationIdOptions> options;

        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CorrelationIdMiddleware"/> class.
        /// </summary>
        /// <param name="next">
        /// The next.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public CorrelationIdMiddleware(RequestDelegate next, IOptions<CorrelationIdOptions> options, ILogger logger)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Invoke(HttpContext context)
        {
            var options = this.options.Value;
            if (!context.Request.Headers.TryGetValue(options.Header, out var correlationId))
            {
                var error = new ApiError("Correlation Id is missing");
                logger.ApiError(error, LogEventLevel.Error);
                return context.WriteErrorAsync(error);
            }

            context.TraceIdentifier = correlationId;
            LogContext.PushProperty("CorrelationId", correlationId);
            context.Response.OnStarting(
                () =>
                    {
                        context.Response.Headers.Add(options.Header, new[] { (string)correlationId });
                        return Task.CompletedTask;
                    });
            return next.Invoke(context);
        }
    }
}
