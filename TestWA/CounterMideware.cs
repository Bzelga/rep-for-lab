using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TestWA.Services;

namespace TestWA
{
    public class CounterMideware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CounterMideware(RequestDelegate next, ILogger<CounterMideware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICounter counter)
        {
            await httpContext.Response.WriteAsync($"Count: {counter.Count} ");
            //_logger.LogInformation("!!!!!!!!!!!!!!!!!!!!");
            await _next(httpContext);
        }
    }
}
