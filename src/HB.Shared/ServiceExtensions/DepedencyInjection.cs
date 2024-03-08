using HB.Shared.Markers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HB.Shared.ServiceExtensions;
public static class DepedencyInjection
{
    public static IServiceCollection RegisterServiceWthMarkerInterface(this IServiceCollection services, Assembly assembly)
    {
        var scopedTypes = assembly.GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IScopedService)) && !x.IsInterface && !x.IsAbstract)
            .ToList();

        foreach (var scopedType in scopedTypes)
        {
            var interfaceType = scopedType.GetInterfaces().FirstOrDefault(x => x != typeof(IScopedService));

            if (interfaceType is not null)
                services.AddScoped(interfaceType, scopedType);
        }

        var transientTypes = assembly.GetTypes()
            .Where(x => x.IsAssignableTo(typeof(ITransientService)) && !x.IsInterface && !x.IsAbstract)
            .ToList();

        foreach (var transientType in transientTypes)
        {
            var interfaceType = transientType.GetInterfaces().FirstOrDefault(x => x != typeof(ITransientService));

            if (interfaceType is not null)
                services.AddTransient(interfaceType, transientType);
        }


        return services;
    }
}
