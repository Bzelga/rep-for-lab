using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TestWA.Services;

namespace TestWA
{
    public class StringMideware
    {
        private readonly RequestDelegate _next;

        public StringMideware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IStringAddertor stringAddertor)
        {
            await httpContext.Response.WriteAsync($"String: {stringAddertor.String} ");
            await _next(httpContext);
        }
    }
}
