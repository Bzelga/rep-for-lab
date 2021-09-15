using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;

        public CounterMiddleware(RequestDelegate next, ILogger<CounterMiddleware> logger)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICounter1 counter)
        {
            await httpContext.Response.WriteAsync($"Count: {counter.Count} ");
            await _next(httpContext);
        }
    }
}
