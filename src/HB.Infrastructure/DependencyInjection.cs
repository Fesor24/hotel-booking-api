using HB.Domain.Services.HotelBed;
using HB.Domain.Services.Http;
using HB.Infrastructure.Services.HotelBed;
using Microsoft.Extensions.DependencyInjection;

namespace HB.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddScoped<IHttpClient, Services.Http.HttpClient>();

        services.AddScoped<IHotelBedService, HotelBedService>();

        return services;
    }
}
