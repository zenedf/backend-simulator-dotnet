using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BackendSimulator.Infrastructure.Data;

public class BackendSimulatorDbContextFactory : IDesignTimeDbContextFactory<BackendSimulatorDbContext>
{
    public BackendSimulatorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BackendSimulatorDbContext>();

        // Use the same path as Program.cs
        var solutionRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), ".."));
        var dataFolder = Path.Combine(solutionRoot, "Data");
        Directory.CreateDirectory(dataFolder);
        var dbPath = Path.Combine(dataFolder, "backend.db");

        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        return new BackendSimulatorDbContext(optionsBuilder.Options);
    }
}