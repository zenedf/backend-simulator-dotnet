using BackendSimulator.ConsoleApp.ConsoleUI;
using BackendSimulator.Application.Services;
using BackendSimulator.Application.Interfaces;
using BackendSimulator.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddLogging(config =>
{
    config.AddConsole();
    config.SetMinimumLevel(LogLevel.Information);
});

// Application services
services.AddSingleton<TaskService>();

// Infrastructure
services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

// Console UI
services.AddSingleton<TaskConsoleRunner>();

var provider = services.BuildServiceProvider();

var runner = provider.GetRequiredService<TaskConsoleRunner>();
runner.Run();

Console.ReadLine();
