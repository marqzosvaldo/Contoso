using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Contoso.Client.Auth;
using Contoso.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Contoso.Client {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            ConfigureServices(builder.Services);

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
        private static void ConfigureServices(IServiceCollection services) {
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, CAuthenticationStateProvider>();
            services.AddScoped<IAuthService, AuthService>();

        }
    }
}