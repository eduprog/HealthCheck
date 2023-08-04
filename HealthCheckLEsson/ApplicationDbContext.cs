using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;

namespace HealthCheckLEsson;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Health> Health => Set<Health>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging(); // Define para ser apresentado logs detalhados
        optionsBuilder.LogTo(Console.WriteLine,
            new[] { RelationalEventId.CommandExecuted });
#endif
    }

    public IDbConnection ConexaoBd => Database.GetDbConnection();

}