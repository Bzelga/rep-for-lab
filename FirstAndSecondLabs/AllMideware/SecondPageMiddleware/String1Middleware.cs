using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class String1Middleware
    {
        private readonly RequestDelegate _next;

        public String1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IString1 string1)
        {
            await httpContext.Response.WriteAsync($"String: {string1.String} ");
            await _next(httpContext);
        }
    }
}
