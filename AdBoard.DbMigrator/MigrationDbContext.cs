using AdBoard.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdBoard.DbMigrator;

public class MigrationDbContext : AdBoardDbContext
{
    public MigrationDbContext(DbContextOptions options) : base(options)
    {
    }
}
