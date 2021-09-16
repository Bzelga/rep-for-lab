using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;

        public SomeStringAndNumber SomeStringAndNumber { get; }

        public CounterMiddleware(RequestDelegate next, IOptions<SomeStringAndNumber> options)
        {
            _next = next;
            SomeStringAndNumber = options.Value;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync($"Count: {SomeStringAndNumber.Number} ");
            await _next(httpContext);
        }
    }
}
