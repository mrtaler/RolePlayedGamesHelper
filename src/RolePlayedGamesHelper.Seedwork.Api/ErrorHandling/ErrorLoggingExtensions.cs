﻿using GurpsAssistant.Seedwork.Api;
using Serilog;
using Serilog.Events;

namespace RolePlayedGamesHelper.Seedwork.Api.ErrorHandling
{
    /// <summary>
    /// The error logging extensions.
    /// </summary>
    public static class ErrorLoggingExtensions
    {
        /// <summary>
        /// Log an <see cref="ApiError"/> using Serilog.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="error">
        /// The error.
        /// </param>
        /// <param name="level">
        /// The level.
        /// </param>
        public static void ApiError(this ILogger logger, ApiError error, LogEventLevel level = LogEventLevel.Warning)
        {
            var errorLogger = logger.ForContext("ErrorId", error.Id);
            errorLogger.Write(level, error.GetException(), error.Description);
        }
    }
}