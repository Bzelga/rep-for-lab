using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class StringMiddleware
    {
        private readonly RequestDelegate _next;

        public StringMiddleware(RequestDelegate next)
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
