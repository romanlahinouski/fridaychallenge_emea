using Microsoft.AspNetCore.Http;
using RestaurantGuide.Application.Orders;
using System;
using System.Threading.Tasks;

namespace RestaurantGuide.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);                
            }
           catch(GuestNotRegisterForAVisitException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"Guest with id {ex.GuestId} is not register for a visit, please register a user first");                
            }
            
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"{ex.Message}");
            }
        }
    }
}
