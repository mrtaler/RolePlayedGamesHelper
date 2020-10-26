using System;
using System.Net;
using GurpsAssistant.Seedwork.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Serilog.Events;

namespace RolePlayedGamesHelper.Seedwork.Api.ErrorHandling
{
    /// <summary>
    /// Exception filter for handling unexpected and expected exceptions that passes through to the framework.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// The log.
        /// </summary>
        private readonly ILogger log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        /// <param name="log">
        /// The log.
        /// </param>
        public ApiExceptionFilterAttribute(ILogger log)
        {
            this.log = log;
        }

        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {
            ApiError error;
            if (context.Exception is /*ServiceValidationException*/Exception ex)
            {
                /*  switch (ex.Error)
                  {
                      case ErrorType.InstanceNotExist:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                          break;
                      case ErrorType.InstanceHasLinkedObjects:
                      case ErrorType.LinkedInstanceNotExist:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                          break;
                      case ErrorType.MissedWorkflow:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                          break;
                      case ErrorType.NameConflict:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                          break;
                      case ErrorType.LongRequest:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestUriTooLong;
                          break;
                      case ErrorType.IncorrectProductSetup:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                          break;
                      case ErrorType.DeniedDependency:
                      case ErrorType.IncorrectMarketSetup:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                          break;
                      default:
                          context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                          break;
                  }*/

                error = new ApiError(ex.Message, ex.GetBaseException());
                log.ApiError(error);
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                error = new ApiError("Unknown error", context.Exception);
                log.ApiError(error, LogEventLevel.Error);
            }

            context.Result = new JsonResult(error);
            base.OnException(context);
        }
    }
}
