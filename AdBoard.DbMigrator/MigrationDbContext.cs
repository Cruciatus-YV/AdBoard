using AdBoard.Infrastructure;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Контекст базы данных, предназначенный для выполнения операций миграции.
/// Наследуется от <see cref="AdBoardDbContext"/>, предоставляя возможности управления миграциями 
/// без изменения основного контекста приложения.
/// </summary>
/// <remarks>
/// Этот конструктор используется для инициализации контекста миграции с переданными параметрами конфигурации <see cref="DbContextOptions"/>
/// </remarks>
/// <param name="options">Параметры конфигурации контекста базы данных</param>
public class MigrationDbContext : AdBoardDbContext
{
    public MigrationDbContext(DbContextOptions<AdBoardDbContext> options)
        : base(options)
    {
    }
}
