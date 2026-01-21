using BackendSimulator.Application.Interfaces;
using BackendSimulator.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BackendSimulator.Application.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly ILogger<TaskService> _logger;

    public TaskService(
        ITaskRepository taskRepository,
        ILogger<TaskService> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public void CreateTask(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            _logger.LogWarning("Attempted to create a task with empty title");
            throw new ArgumentException("Task title cannot be empty");
        }

        var task = new TaskItem(title);

        _taskRepository.Add(task);

        _logger.LogInformation("Task created with ID: {TaskId}", task.Id); // look into potentially making this less expensive. [ CA1873 ]
    }

    public IReadOnlyList<TaskItem> GetAllTasks() =>
        _taskRepository.GetAll();
}
