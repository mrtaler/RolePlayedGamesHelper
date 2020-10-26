using System.Net;
using System.Threading.Tasks;
using GurpsAssistant.Seedwork.Api;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RolePlayedGamesHelper.Seedwork.Api.ErrorHandling
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// The json content type.
        /// </summary>
        private const string JsonContentType = "application/json; charset=utf-8";

        /// <summary>
        /// Write an <see cref="ApiError"/>
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="error">
        /// The error.
        /// </param>
        /// <param name="responseCode">
        /// The response Code.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static Task WriteErrorAsync(
            this HttpContext context,
            ApiError         error,
            HttpStatusCode   responseCode = HttpStatusCode.BadRequest)
        {
            var errorJson = JsonConvert.SerializeObject(error);
            context.Response.StatusCode  = (int)responseCode;
            context.Response.ContentType = JsonContentType;
            return context.Response.WriteAsync(errorJson);
        }
    }
}