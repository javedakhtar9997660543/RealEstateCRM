using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using AdminProject.PresentationLayer.WebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AdminProject.PresentationLayer.WebApi.CustomFilters
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;


        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                var correlationId = context.Request.Headers["X-Correlation-ID"].ToString();
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException _:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException _:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                _logger.LogError("[CorrelationID] " + correlationId + "[Message]  " + error.Message);
                _logger.LogError(error.StackTrace);

                var result = JsonSerializer.Serialize(new { message = error.Message, requestId = correlationId, isSuccess = false, singleResult = string.Empty });
                await response.WriteAsync(result);
            }
        }
    }
}
