using HB.Domain.Primitives;
using HB.Domain.Services.HotelBed;
using HB.Domain.Services.Http;
using HB.Infrastructure.Data;
using HB.Infrastructure.Repository;
using HB.Infrastructure.Services.HotelBed;
using HB.Shared.ServiceExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System.Reflection;

namespace HB.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpClient();

        services.AddScoped<IHttpClient, Services.Http.HttpClient>();

        services.AddScoped<IHotelBedService, HotelBedService>();

        services.AddSingleton<HotelDbContext>();

        services.AddSingleton<IMongoClient>(new MongoClient(config.GetConnectionString("DefaultConnection")));

        services.AddSingleton((sp) =>
        {
            var client = sp.GetRequiredService<IMongoClient>();

            return client.GetDatabase(config["Database"]);
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.RegisterServiceWthMarkerInterface(Assembly.GetExecutingAssembly());

        return services;
    }
}
