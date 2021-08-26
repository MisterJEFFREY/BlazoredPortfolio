using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

//Intended for cookie purposes
using Blazored.SessionStorage;

namespace BlazoredPortfolio
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //Intended for cookie purposes via Blazor
            builder.Services.AddBlazoredSessionStorage();
            //HELP SRC:https://www.syncfusion.com/faq/blazor/web-api/how-do-i-store-session-data-in-blazor-webassembly
            await builder.Build().RunAsync();
        }
    }
}
