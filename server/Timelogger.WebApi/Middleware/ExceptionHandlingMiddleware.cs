using System.Text.Json;
using Timelogger.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Timelogger.WebApi.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Timelogger.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;


            if (exception != null)
            { 
                var apiException = exception as ApiException;                

                context.Response.StatusCode = ((int?)apiException?.StatusCode) ?? 500;
                context.Response.ContentType = "application/json";
                var errorResponse = new ErrorResponse(exception.GetType().Name, exception.Message);

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }));
            }
        }
    }
}
