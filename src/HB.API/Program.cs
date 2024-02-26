using HB.Application;
using HB.Application.Features.Hotel.Queries.CheckStatus;
using HB.Infrastructure;
using HB.Infrastructure.Configurations;
using MediatR;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog();

builder.Services.AddInfrastructureServices()
    .AddApplicationServices();

builder.Services.Configure<HotelBedConfiguration>(
    builder.Configuration.GetSection(HotelBedConfiguration.CONFIGURATION_NAME));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("api/hotel/status", async (MediatR.ISender sender) =>
{
    var res = await sender.Send(new CheckStatusRequest());

    return Results.Ok(res.Value);
});

app.UseSerilogRequestLogging();

app.Run();
