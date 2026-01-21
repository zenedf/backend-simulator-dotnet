using BackendSimulator.Domain.Entities;

namespace BackendSimulator.Application.Interfaces;

public interface ITaskRepository
{
    void Add(TaskItem task);
    IReadOnlyList<TaskItem> GetAll();
}
