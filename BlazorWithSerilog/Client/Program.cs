using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorWithSerilog.Shared;

namespace BlazorWithSerilog.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient(typeof(IMessageLogger<>), typeof(ClientMessageLogger<>));
            builder.Services.AddSingleton<IMessageLogConfiguration>(new MessageLogConfiguration());
            builder.Services.AddTransient<ILogHistory, LogHistory>();

            await builder.Build().RunAsync();
        }
    }
}
