namespace API.Middleware
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using API.Errors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class ExceptionMiddleware
    {
        /// <summary>The next</summary>
        private readonly RequestDelegate next;

        /// <summary>The logger</summary>
        private readonly ILogger<ExceptionMiddleware> logger;

        /// <summary>The env</summary>
        private readonly IHostEnvironment env;

        /// <summary>Initializes a new instance of the <see cref="ExceptionMiddleware" /> class.</summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="env">The env.</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        /// <summary>Invokes the asynchronous.</summary>
        /// <param name="context">The context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = this.env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
