using HB.API.Shared;
using System.Reflection;

namespace HB.API.Extensions;

public static class EndpointExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        var endpoints = Assembly.GetExecutingAssembly()
            .GetExportedTypes()
            .Where(x => x.IsAssignableTo(typeof(IEndpoint)) && !x.IsInterface && !x.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>()
            .ToList();

        foreach (var endpoint in endpoints)
            endpoint.Register(app);
    }
}
