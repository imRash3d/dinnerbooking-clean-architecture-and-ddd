using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DinnerBooking.Api.Middlewares
{
    public class ErrorHandlingMiddleware:IMiddleware
    {
       
      
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                
                await HnadleExceptionAsync(context, ex);
            }
        }


        private static async Task HnadleExceptionAsync(HttpContext context , Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Internal Server Error",
                Detail = ex.Message
            };
            string result = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(result);
        }
    }
}
