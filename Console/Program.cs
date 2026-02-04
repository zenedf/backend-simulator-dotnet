using BackendSimulator.ConsoleApp.ConsoleUI;
using BackendSimulator.Application.Services;
using BackendSimulator.Application.Interfaces;
using BackendSimulator.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BackendSimulator.Infrastructure.Data;

var services = new ServiceCollection();

services.AddLogging(config =>
{
    config.AddConsole();
    config.SetMinimumLevel(LogLevel.Information);
});

// Application services
services.AddSingleton<TaskService>();

// Infrastructure - EF Core with SQLite
services.AddDbContext<BackendSimulatorDbContext>(options =>
    options.UseSqlite("Data Source=backend.db"));

services.AddScoped<ITaskRepository, InMemoryTaskRepository>();

// Console UI
services.AddSingleton<TaskConsoleRunner>();

// Build the service provider
var provider = services.BuildServiceProvider();

// Ensure database is created and migrations are applied
using (var scope = provider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BackendSimulatorDbContext>();
    context.Database.Migrate();
}

var runner = provider.GetRequiredService<TaskConsoleRunner>();
runner.Run();

Console.ReadLine();
