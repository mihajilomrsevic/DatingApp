namespace API.Errors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ApiException
    {
        /// <summary>Initializes a new instance of the <see cref="ApiException" /> class.</summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        public ApiException(int statusCode, string message, string details = null)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Details = details;
        }

        /// <summary>Gets or sets the status code.</summary>
        /// <value>The status code.</value>
        public int StatusCode { get; set; }

        /// <summary>Gets or sets the message.</summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>Gets or sets the details.</summary>
        /// <value>The details.</value>
        public string Details { get; set; }
    }
}
