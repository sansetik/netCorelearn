using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication2
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                string path = context.Request.Path.Value.ToLower();
                if (path == "/index")
                {
                    await context.Response.WriteAsync("Home Page");
                }
                else if (path == "/about")
                {
                    await context.Response.WriteAsync("About");
                }
                else
                {
                    context.Response.StatusCode = 404;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
            
        }
    }
}