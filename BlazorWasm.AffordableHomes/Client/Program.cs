using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasm.AffordableHomes.Client;
using BlazorWasm.AffordableHomes.Client.Services.HouseServices;
using BlazorWasm.AffordableHomes.Client.Services.ModeServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IModeService, ModeService>();
await builder.Build().RunAsync();

