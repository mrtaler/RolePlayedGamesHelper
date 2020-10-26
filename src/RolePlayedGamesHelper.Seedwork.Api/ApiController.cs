//using System.IO;
//using System.Linq;
//using GurpsAssistant.Seedwork.Api.ServiceDomain;
//using GurpsAssistant.Seedwork.Cqrs.Kledex;
//using Microsoft.AspNetCore.Mvc;

//namespace GurpsAssistant.Seedwork.Api
//{
//    /// <inheritdoc />
//    [ApiController]
//    [Produces("application/json")]
//    public abstract class ApiController : ControllerBase
//    {
//        /// <summary>
//        /// In process messaging service. Glue between layers of the application
//        /// </summary>
//        protected IDispatcher Dispatcher => (IDispatcher)HttpContext.RequestServices.GetService(typeof(IDispatcher));

//        /// <summary>
//        /// The notify model state errors.
//        /// </summary>
//        protected void NotifyModelStateErrors()
//        {
//            var errors = ModelState.Values.SelectMany(v => v.Errors);
//            foreach (var error in errors)
//            {
//                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
//                NotifyError(string.Empty, errorMsg);
//            }
//        }

//        /// <summary>
//        /// The notify error.
//        /// </summary>
//        /// <param name="code">
//        /// The code.
//        /// </param>
//        /// <param name="message">
//        /// The message.
//        /// </param>
//        protected void NotifyError(string code, string message)
//        {
//            Dispatcher.PublishAsync(new ServiceDomainEvent(code, message));
//        }

//        /// <summary>
//        /// Provides stream result with custom name.<para/>
//        /// This could act as a file name after downloading process
//        /// </summary>
//        /// <param name="contentStream">stream which will be wrapped</param>
//        /// <param name="contentName">name of the stream</param>
//        /// <returns>named stream result</returns>
//        protected FileStreamResult NamedStreamContent(Stream contentStream, string contentName)
//        {
//            contentStream.Position = 0;
//            var namedStreamContent = new FileStreamResult(contentStream, GetStreamContentTypeByFileName(contentName))
//            {
//                FileDownloadName = contentName
//            };

//            return namedStreamContent;
//        }

//        /// <summary>
//        /// Performs mapping of the desired file by name and match it to the set of mime types
//        /// </summary>
//        /// <param name="fileName">name of the file with exclusion of extension</param>
//        /// <returns>mime type string value</returns>
//        private string GetStreamContentTypeByFileName(string fileName)
//        {
//            /*var contentTypeProvider = (IContentTypeProvider)HttpContext.RequestServices.GetService(typeof(IContentTypeProvider));
//            contentTypeProvider.TryGetContentType(fileName, out var contentType);
//            return contentType ??*/return "application/octet-stream";
//        }
//    }
//}
