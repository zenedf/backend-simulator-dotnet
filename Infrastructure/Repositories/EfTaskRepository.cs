using BackendSimulator.Application.Interfaces;
using BackendSimulator.Domain.Entities;
using BackendSimulator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EfTaskRepository : ITaskRepository
{
    private readonly BackendSimulatorDbContext _context;

    public EfTaskRepository(BackendSimulatorDbContext context) =>
        _context = context;

    public void Add(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public IReadOnlyList<TaskItem> GetAll() =>
        _context.Tasks.AsNoTracking().ToList();
}
