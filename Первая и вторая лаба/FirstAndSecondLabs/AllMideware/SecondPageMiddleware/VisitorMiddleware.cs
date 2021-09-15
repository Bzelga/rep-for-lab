using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class VisitorMiddleware
    {
        private readonly RequestDelegate _next;

        public VisitorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICounter2 counter)
        {
            await httpContext.Response.WriteAsync($"Visit: {counter.Count} ");
            await _next(httpContext);
        }
    }
}
