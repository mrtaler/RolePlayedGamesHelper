using System;
using Newtonsoft.Json;

namespace RolePlayedGamesHelper.Seedwork.Api
{
    /// <summary>
    /// The api error.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// The exception.
        /// </summary>
        private readonly Exception exception;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class.
        /// </summary>
        /// <param name="description">Overall description of error explaining which part of system in general is broken</param>
        /// <param name="exception">The exception that caused the error</param>
        [JsonConstructor]
        public ApiError(string description, Exception exception = null)
        {
            Description = description;
            Id = Guid.NewGuid();
            this.exception = exception;
        }

        /// <summary>
        /// Overall description of error explaining which part of system in general is broken
        /// </summary>
        /// <example>
        /// The API-user level description of the error goes here
        /// </example>
        public string Description { get; }

        /// <summary>
        /// Unique error ID for tracking purposes
        /// </summary>
        /// <example>
        /// 415f6a9a-a7cd-1956-9a37-54758e49b25b
        /// </example>
        public Guid Id { get; }

        /// <summary>
        /// Returns a string representation of ApiError
        /// </summary>
        public override string ToString()
        {
            return $"[{Id}] {Description}";
        }

        /// <summary>
        /// Returns the exception that caused the error, if any
        /// </summary>
        public Exception GetException()
        {
            return exception;
        }
    }
}
