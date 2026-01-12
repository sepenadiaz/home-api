using System.Reflection;

namespace Home.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, Assembly assembly)
        {
            // Get all types in the assembly
            var types = assembly.GetTypes()
                                .Where(t => t.IsClass && !t.IsAbstract) // Only concrete classes
                                .Where(t => t.GetInterfaces().Any()) // Only types that implement interfaces
                                .ToList();

            // Register services and repositories
            foreach (var implementation in types)
            {
                foreach (var interfaceType in implementation.GetInterfaces())
                {
                    // Register the service as Scoped if it's not already registered
                    if (!services.Any(service => service.ServiceType == interfaceType))
                    {
                        services.AddScoped(interfaceType, implementation);
                    }
                }
            }
        }
    }
}


