using BackendSimulator.Application.Services;
using Microsoft.Extensions.Logging;

namespace BackendSimulator.ConsoleApp.ConsoleUI;

public class TaskConsoleRunner
{
    private readonly TaskService _taskService;
    private readonly ILogger<TaskConsoleRunner> _logger;

    private readonly string _menu = "=== Task Backend Simulator ===\n" +
        "1. Create task\n" +
        "2. List tasks\n" +
        "0. Exit\n" +
        "Select an option: ";

    public TaskConsoleRunner(
        TaskService taskService,
        ILogger<TaskConsoleRunner> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("Task Console Runner started.");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine(_menu);

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateTask();
                    break;
                case "2":
                    ListTasks();
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        _logger.LogInformation("Task Console Runner stopped.");
    }

    private void CreateTask()
    {
        Console.WriteLine("Enter task title: ");
        var title = Console.ReadLine();

        try
        {
            _taskService.CreateTask(title!);
            Console.WriteLine("Task created successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ListTasks()
    {
        var tasks = _taskService.GetAllTasks();

        if (!tasks.Any())
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        Console.WriteLine("Tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"- {task.Id}: {task.Title}");
        }
    }

}

