global using Microsoft.AspNetCore.Components;
global using MarketBayBlazor.Shared;
global using System.Net.Http.Json;
global using MarketBayBlazor.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MarketBayBlazor.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFeiraService, FeiraService>();
builder.Services.AddScoped<IStandService, StandService>();

await builder.Build().RunAsync();

