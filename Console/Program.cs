using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();

services.AddLogging(config =>
{
    config.AddConsole();
    config.SetMinimumLevel(LogLevel.Information);
});

var provider = services.BuildServiceProvider();

var logger = provider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Backend Simulator started successfully.");

Console.ReadLine();
