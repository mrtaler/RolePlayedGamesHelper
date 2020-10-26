using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace GurpsAssistant.Seedwork.Api
{
    /// <summary>
    /// The operation id enricher.
    /// </summary>
    public class OperationIdEnricher : ILogEventEnricher
    {
        /// <summary>
        /// The enrich.
        /// </summary>
        /// <param name="logEvent">
        /// The log event.
        /// </param>
        /// <param name="propertyFactory">
        /// The property factory.
        /// </param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var activity = Activity.Current;

            if (activity is null)
            {
                return;
            }

            logEvent.AddPropertyIfAbsent(new LogEventProperty("Operation Id", new ScalarValue(activity.Id)));
            logEvent.AddPropertyIfAbsent(new LogEventProperty("Parent Id",    new ScalarValue(activity.ParentId)));
        }
    }
}