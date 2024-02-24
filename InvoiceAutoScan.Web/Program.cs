using InvoiceAutoScan.Core.Infrastructure;
using InvoiceAutoScan.Gateway.Auth.Google;
using InvoiceAutoScan.Gateway.Config;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddIASAppConfiguration();
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect("Endpoint=https://ias-dev-uksouth.azconfig.io;Id=fGZx;Secret=4ioYkWcOYgSyiwOBABSJaJiHX75fk1wjDk8Dm8fr1a4=");
    options.Select("*", labelFilter: "DEV");
});

#if DEBUG
Console.WriteLine(builder.Configuration.GetDebugView());
builder.Configuration.GetSection("Google");
#endif

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCoreServices(builder.Configuration);

builder.Services.ConfigureGoogleAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
