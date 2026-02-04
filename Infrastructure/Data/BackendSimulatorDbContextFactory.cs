using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BackendSimulator.Infrastructure.Data;

public class BackendSimulatorDbContextFactory : IDesignTimeDbContextFactory<BackendSimulatorDbContext>
{
    public BackendSimulatorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BackendSimulatorDbContext>();
        optionsBuilder.UseSqlite("Data Source=backend.db");

        return new BackendSimulatorDbContext(optionsBuilder.Options);
    }
}