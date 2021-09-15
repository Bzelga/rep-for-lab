using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ThirdLab
{
    public class Startup
    {
        //понять, как работает дефолтная страничка и конвеер
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");

            app.UseStatusCodePages("text/plain", "Error. Status code : {0}");
            app.Map("/error", ShowError);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Result = {Convert.ToInt32("q")}");
            //});
        }

        private static void ShowError(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"Не удалось сконвертировать строку в число");
            });
        }
    }
}
