using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdBoard.DataAccess;

public class AdBoardDbContext : DbContext
{
    public AdBoardDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
