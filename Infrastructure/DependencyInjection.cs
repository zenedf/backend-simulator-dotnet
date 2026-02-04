
using BackendSimulator.Application.Interfaces;
using BackendSimulator.Infrastructure.Data;
using BackendSimulator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackendSimulator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register infrastructure services here
        services.AddDbContext<BackendSimulatorDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("Default")));

        services.AddScoped<ITaskRepository, EfTaskRepository>();

        return services;
    }
}
