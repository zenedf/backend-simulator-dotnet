
using BackendSimulator.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BackendSimulator.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services here
        services.AddScoped<TaskService>();
        return services;
    }
}
