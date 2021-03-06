using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using CorePos.Blazor.Services;
using CorePos.Blazor.Data;


namespace CorePos.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<UserBL>();
            builder.Services.AddScoped<ReferencesBL>();
            builder.Services.AddScoped<ReportBL>();
            builder.Services.AddScoped<SalesBL>();
            builder.Services.AddSingleton<AppState>();
            
            await builder.Build().RunAsync();
        }
    }
}
