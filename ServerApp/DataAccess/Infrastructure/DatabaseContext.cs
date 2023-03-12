using Model;
using Microsoft.EntityFrameworkCore;  

namespace DataAccess.Infrastructure;

public class DatabaseContext:DbContext
{
    public DbSet<WorkTask> WorkTasks { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskStateRecord> TaskStateHistory{ get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

}
