using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace FirstAndSecondLabs
{
    public class Startup
    {
        private readonly IConfiguration _appConfiguration;

        public Startup(IConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITimeSender, TimeService>();
            services.AddTransient<ICounter1, CounterService>();
            services.AddScoped<IStringAddertor, FirstPageStringServace>();
            services.AddSingleton<ICounter2, CounterVisitorServace>();
            services.AddTransient<ICounter3, RandomNumberServace>();
            services.AddTransient<IString1, SecondPageStringServace>();

            services.Configure<SomeStringAndNumber>(_appConfiguration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Map("/first", FirstTestMethod);
            app.Map("/second", SecondTestMethod);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"<a href=\"https://localhost:44332/first\">first link</a><br/><a href=\"https://localhost:44332/second\">second link </a>");
            });
        }

        private static void FirstTestMethod(IApplicationBuilder app)
        {
            app.UseMiddleware<TimeMiddleware>();
            app.UseMiddleware<CounterMiddleware>();
            app.UseMiddleware<StringMiddleware>();
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("200");
            });
        }

        private static void SecondTestMethod(IApplicationBuilder app)
        {
            app.UseMiddleware<RandomNumberMiddleware>();
            app.UseMiddleware<String1Middleware>();
            app.UseMiddleware<VisitorMiddleware>();
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("200");
            });
        }
    }
}
