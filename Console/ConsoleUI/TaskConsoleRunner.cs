using BackendSimulator.Application.Services;
using Microsoft.Extensions.Logging;

namespace BackendSimulator.ConsoleApp.ConsoleUI;

public class TaskConsoleRunner
{
    private readonly TaskService _taskService;
    private readonly ILogger<TaskConsoleRunner> _logger;

    public TaskConsoleRunner(
        TaskService taskService,
        ILogger<TaskConsoleRunner> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("Starting Task Console Runner...");

        _taskService.CreateTask("Learn clean architecture");
        _taskService.CreateTask("Understand dependency injection");

        var tasks = _taskService.GetAllTasks();

        foreach (var task in tasks)
            Console.WriteLine($"- {task.Id}: {task.Title}");
    }
}

