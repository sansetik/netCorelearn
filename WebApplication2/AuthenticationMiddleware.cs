﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication2
{
    public class AuthenticationMiddleware
    {
        public RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}