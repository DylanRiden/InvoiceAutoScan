using InvoiceAutoScan.FrontEnd.ApiClient.Infrastructure;
using InvoiceAutoScan.FrontEnd.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddIasApiSerivces(builder.Configuration);
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
