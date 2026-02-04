using BackendSimulator.ConsoleApp.ConsoleUI;
using BackendSimulator.Application.Services;
using BackendSimulator.Application.Interfaces;
using BackendSimulator.Infrastructure.Repositories;
using BackendSimulator.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

var services = new ServiceCollection();

services.AddLogging(config =>
{
    config.AddConsole();
    config.SetMinimumLevel(LogLevel.Information);
});

// Application services
services.AddSingleton<TaskService>();

// Infrastructure - EF Core with SQLite
var solutionRoot = GetSolutionRoot();
var dataFolder = Path.Combine(solutionRoot, "Data");
Directory.CreateDirectory(dataFolder); // Ensure folder exists
var dbPath = Path.Combine(dataFolder, "backend.db");

services.AddDbContext<BackendSimulatorDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// EF Core with SQLite
services.AddScoped<ITaskRepository, EfTaskRepository>();

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

// Find the solution root by searching for .sln file
static string GetSolutionRoot()
{
    // Start from the executable location
    var directory = new DirectoryInfo(AppContext.BaseDirectory);
    
    // Walk up the directory try until we find a .slnx file
    while (directory != null &&
        directory.GetFiles("*.sln").Length == 0 &&
        directory.GetFiles("*.slnx").Length == 0)
    {
        directory = directory.Parent;
    }

    // If we found it, return that directory; otherwise fall back to current directory
    return directory?.FullName ?? Directory.GetCurrentDirectory();
}
