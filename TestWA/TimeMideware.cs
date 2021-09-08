using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TestWA.Services;

namespace TestWA
{
    public class TimeMideware
    {
        private readonly RequestDelegate _next;

        public TimeMideware(RequestDelegate next)
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
