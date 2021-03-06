using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Prelast;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrelastLab
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services
                .AddConferenceClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:5001/graphql/"));

            await builder.Build().RunAsync();
        }
    }
}
