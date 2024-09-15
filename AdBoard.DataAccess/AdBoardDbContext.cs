using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace AdBoard.DataAccess;

/// <summary>
/// Класс AdBoardDbContext наследует DbContext и используется для взаимодействия с базой данных.
/// </summary>
public class AdBoardDbContext : DbContext
{
    /// <summary>
    /// Конструктор принимает объект DbContextOptions, который содержит параметры конфигурации контекста БД.
    /// </summary>
    public AdBoardDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
