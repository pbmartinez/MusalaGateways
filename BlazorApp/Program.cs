using BlazorApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "";
//var clin = new HttpClient();
//clin.DefaultRequestHeaders.c
builder.Services.AddScoped(sp => 
    new HttpClient {
        BaseAddress = new Uri(apiBaseUrl)
        
});

builder.Services.AddLocalization();
builder.Services.AddMudServices();

await builder.Build().RunAsync();