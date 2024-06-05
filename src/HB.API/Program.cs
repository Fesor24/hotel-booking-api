using HB.API.Extensions;
using HB.API.Middleware;
using HB.Application;
using HB.Infrastructure;
using HB.Infrastructure.Configurations;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddSwaggerGen(gen =>
{
    gen.CustomSchemaIds(c => c.ToString());
    gen.SwaggerDoc("Main", new OpenApiInfo
    {
        Title = "Main endpoints",
        Description = "Endpoints collection under Main",
        Version = "v1"
    });
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
    s.RoutePrefix = "swagger";
    s.SwaggerEndpoint("/swagger/Main/swagger.json", "Hotel Booking API v.1");
});

app.MapEndpoints();

app.UseSerilogRequestLogging();

app.Run();
