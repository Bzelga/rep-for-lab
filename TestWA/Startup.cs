using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestWA.Services;

namespace TestWA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<ITimeSender,TimeService>();
            services.AddTransient<ICounter, CounterService>();
            services.AddScoped<IStringAddertor,StringService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<TimeMideware>();
            app.UseMiddleware<CounterMideware>();
            app.UseMiddleware<StringMideware>();
        }
    }
}
