global using Microsoft.AspNetCore.Components;
global using MarketBayBlazor.Shared;
global using System.Net.Http.Json;
global using MarketBayBlazor.Client.Services;
global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MarketBayBlazor.Client;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IFeiraService, FeiraService>();
builder.Services.AddScoped<IStandService, StandService>();
builder.Services.AddScoped<IPropostaService, PropostaService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IFeiranteService, FeiranteService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddBlazoredLocalStorage(); 

await builder.Build().RunAsync();