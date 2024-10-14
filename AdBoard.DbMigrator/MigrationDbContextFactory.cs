using AdBoard.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AdBoard.DbMigrator;

/// <summary>
/// Фабрика для создания экземпляров контекста базы данных <see cref="MigrationDbContext"/>.
/// Используется во время проектирования для создания контекста с конфигурацией подключения,
/// указанной в файле конфигурации, что позволяет выполнять миграции и другие операции проектирования.
/// </summary>
public class MigrationDbContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
{
    /// <summary>
    /// Создает экземпляр контекста базы данных <see cref="MigrationDbContext"/> с использованием
    /// параметров подключения, указанных в файле конфигурации.
    /// </summary>
    /// <param name="args">Массив строковых аргументов, которые могут быть переданы (не используются в этом методе).</param>
    /// <returns>Экземпляр <see cref="MigrationDbContext"/> с настроенными параметрами подключения.</returns>
    public MigrationDbContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();

        var connectionString = configuration.GetConnectionString("ConnectionString");

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<AdBoardDbContext>(); 
        dbContextOptionsBuilder.UseNpgsql(connectionString);

        return new MigrationDbContext(dbContextOptionsBuilder.Options);
    }
}
