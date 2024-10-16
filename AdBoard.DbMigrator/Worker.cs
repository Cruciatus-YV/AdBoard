namespace AdBoard.DbMigrator;

/// <summary>
/// Фоновая служба, выполняющая задачу в фоне на протяжении всего времени работы приложения.
/// Наследует от <see cref="BackgroundService"/> и реализует метод <see cref="ExecuteAsync(CancellationToken)"/>.
/// </summary>
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    /// <summary>
    /// Конструктор для инициализации фона службы с предоставленным логгером.
    /// </summary>
    /// <param name="logger">Логгер для записи сообщений и событий, связанных с работой службы.</param>
    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Метод, который выполняет фоновую задачу. Служба выполняется до тех пор, пока не будет запрошено её завершение.
    /// Логирует текущее время каждую секунду и ожидает до следующей итерации.
    /// </summary>
    /// <param name="stoppingToken">Токен отмены для контроля прерывания выполнения.</param>
    /// <returns>Задача, представляющая выполнение фоновой работы.</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
