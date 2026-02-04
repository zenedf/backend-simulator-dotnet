using BackendSimulator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendSimulator.Infrastructure.Data;

public class BackendSimulatorDbContext : DbContext
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    public BackendSimulatorDbContext(
        DbContextOptions<BackendSimulatorDbContext> options)
        : base(options)
    {
    }
}
