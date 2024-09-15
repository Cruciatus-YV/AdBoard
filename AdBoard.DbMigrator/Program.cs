namespace AdBoard.DbMigrator;

public class Program
{
    /// <summary>
    /// Основной метод для запуска приложения.
    /// Создает и настраивает хост, добавляет необходимые службы и запускает приложение.
    /// </summary>
    /// <param name="args">Аргументы командной строки, переданные приложению.</param>
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        host.Run();
    }
}