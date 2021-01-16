using System;
using System.Threading.Tasks;
using AdminProject.CommonLayer.Aspects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace AdminProject.CommonLayer.Infrastructure
{
/// <summary>
    /// Middleware which attempts to reads / creates a Correlation ID that can then be used in logs and 
    /// passed to upstream requests.
    /// </summary>
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CorrelationIdOptions _options;
    
        public CorrelationIdMiddleware(RequestDelegate next, IOptions<CorrelationIdOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next ?? throw new ArgumentNullException(nameof(next));
            _options = options.Value;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue(_options.Header, out StringValues correlationId))
            {
                context.TraceIdentifier = correlationId;
            }

            if (_options.IncludeInResponse)
            {
                // apply the correlation ID to the response header for client side tracking
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add(_options.Header, new[] { context.TraceIdentifier });
                    return Task.CompletedTask;
                });
            }

            return _next(context);
        }
    }

}
