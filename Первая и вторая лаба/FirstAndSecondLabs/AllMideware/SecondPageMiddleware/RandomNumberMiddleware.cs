using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class RandomNumberMiddleware
    {
        private readonly RequestDelegate _next;

        public RandomNumberMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICounter3 randomCounter)
        {
            await httpContext.Response.WriteAsync($"Start: {randomCounter.Count} ");
            await _next(httpContext);
        }
    }
}
