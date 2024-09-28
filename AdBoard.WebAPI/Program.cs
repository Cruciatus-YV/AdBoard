using AdBoard.ComponentRegistrar;
using AdBoard.DataAccess;
using AdBoard.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;

// Создание нового экземпляра `WebApplicationBuilder`.
// Это начало настройки приложения, которое включает конфигурацию сервисов и параметров приложения.
var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер зависимостей.
builder.Services.AddControllers();

// Узнайте больше о конфигурации Swagger/OpenAPI по адресу https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Добавляем Swagger для генерации документации API
builder.Services.AddSwaggerGen();

// Регистрация пользовательских сервисов в контейнере зависимостей
builder.Services.AddServices();

// Настройка контекста базы данных для использования PostgreSQL
builder.Services.AddDbContext<AdBoardDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"))
);

// Создание экземпляра приложения на основе настроек, заданных в `builder`.
// Это завершает настройку и конфигурацию приложения и подготавливает его к запуску.
var app = builder.Build();

// Добавляет промежуточное ПО для обработки исключений на уровне всего приложения.
// Это позволяет перехватывать и обрабатывать необработанные исключения, возвращая клиенту понятный ответ.
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Конфигурация конвейера обработки HTTP-запросов.
if (app.Environment.IsDevelopment())
{
    // Включаем Swagger для отображения документации API в режиме разработки
    app.UseSwagger();

    // Включаем интерфейс Swagger UI для взаимодействия с документацией API
    app.UseSwaggerUI();
}

// Включаем перенаправление с HTTP на HTTPS
app.UseHttpsRedirection();

// Включаем обработку авторизации
app.UseAuthorization();

// Маршрутизация запросов к контроллерам
app.MapControllers();

// Запуск приложения
app.Run();