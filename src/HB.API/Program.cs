using HB.API.Extensions;
using HB.API.Middleware;
using HB.Application;
using HB.Infrastructure;
using HB.Infrastructure.Configurations;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Hotel Booking API", Version = "v1" });
});

builder.Services.AddSerilog();

builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();

builder.Services.Configure<HotelBedConfiguration>(
    builder.Configuration.GetSection(HotelBedConfiguration.CONFIGURATION_NAME));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();

app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Booking API v.1");
});

app.RegisterEndpoints();

app.UseSerilogRequestLogging();

app.Run();
