using BackendSimulator.api.Contracts.Tasks;
using BackendSimulator.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendSimulator.api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public IActionResult Create(CreateTaskRequest request)
    {
        _taskService.CreateTask(request.Title);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tasks = _taskService.GetAllTasks();

        var response = tasks.Select(t =>
            new TaskResponse(t.Id, t.Title));

        return Ok(response);
    }

}
