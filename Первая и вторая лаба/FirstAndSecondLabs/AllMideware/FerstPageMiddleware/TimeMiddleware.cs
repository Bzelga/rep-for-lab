using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstAndSecondLabs
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ITimeSender timeSender)
        {
            await httpContext.Response.WriteAsync($"Start: {timeSender.DataTime} ");
            await _next(httpContext);
        }
    }
}
