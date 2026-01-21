using BackendSimulator.Application.Interfaces;
using BackendSimulator.Domain.Entities;

namespace BackendSimulator.Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public void Add(TaskItem task) =>
        _tasks.Add(task);

    public IReadOnlyList<TaskItem> GetAll() =>
        _tasks;
}
