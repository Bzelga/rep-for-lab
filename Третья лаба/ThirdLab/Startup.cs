using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ThirdLab
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(configure => configure.Run(async (context) =>
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"Не удалось сконвертировать строку в число");
            }));

            app.Map("/makeError", MakeError);
            app.UseStatusCodePagesWithRedirects("/{0}.html");

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }

        private static void MakeError(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"{Convert.ToDouble("f")}");
            });
        }
    }
}
