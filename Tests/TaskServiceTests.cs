using BackendSimulator.Application.Interfaces;
using BackendSimulator.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace BackendSimulator.Tests;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _repoMock;
    private readonly Mock<ILogger<TaskService>> _loggerMock;
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        _repoMock = new Mock<ITaskRepository>();
        _loggerMock = new Mock<ILogger<TaskService>>();

        _taskService = new TaskService(
            _repoMock.Object,
            _loggerMock.Object
        );
    }

    [Fact]
    public void CreateTask_ValidTitle_AddsTaskToRepository()
    {
        // Arrange
        var title = "Test Task";
        // Act
        _taskService.CreateTask(title);
        // Assert
        _repoMock.Verify(
            r => r.Add(It.Is<Domain.Entities.TaskItem>(t => t.Title == title)),
            Times.Once
        );
    }
}
