using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdBoard.Infrastructure;

/// <summary>
/// Класс AdBoardDbContext наследует IdentityDbContext и используется для взаимодействия с базой данных.
/// </summary>
public class AdBoardDbContext : IdentityDbContext<UserEntity>
{
    /// <summary>
    /// Конструктор принимает объект DbContextOptions, который содержит параметры конфигурации контекста БД.
    /// </summary>
    public AdBoardDbContext(DbContextOptions<AdBoardDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Применение конфигураций из текущей сборки
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Другие настройки модели, если необходимо
    }
}

