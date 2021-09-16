using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class StringMiddleware
    {
        private readonly RequestDelegate _next;

        public SomeStringAndNumber SomeStringAndNumber { get; }

        public StringMiddleware(RequestDelegate next, IOptions<SomeStringAndNumber> options)
        {
            _next = next;
            SomeStringAndNumber = options.Value;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync($"String: {SomeStringAndNumber.SomeString} ");
            await _next(httpContext);
        }
    }
}
