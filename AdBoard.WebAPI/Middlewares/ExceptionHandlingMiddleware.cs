using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Exceptions;
using System.Net;
using System.Text.Json;
using EntityNotFoundException = AdBoard.AppServices.Exceptions.EntityNotFoundException;

namespace AdBoard.WebAPI.Middlewares
{
    /// <summary>
    /// Промежуточное ПО для обработки ошибок.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly RequestDelegate _next;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ExceptionHandlingMiddleware"/>.
        /// </summary>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Выполняет операцию промежуточного ПО и передаёт управление
        /// </summary>
        /// <param name="context"></param>
        /// <param name="environment"></param>
        /// <param name="serviceProvider"></param>
        public async Task Invoke(HttpContext context, 
                                 IHostEnvironment environment, 
                                 IServiceProvider serviceProvider)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var logger = serviceProvider.GetService<ILogger<ExceptionHandlingMiddleware>>();
                logger?.LogError(e, "Произошла ошибка: {ErrorMessage}", e.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)GetStatusCode(e);

                var apiError = CreateApiError(e, context, environment);
                await context.Response.WriteAsync(JsonSerializer.Serialize(apiError, JsonSerializerOptions));
            }
        }

        private object CreateApiError(Exception exception, HttpContext context, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                return new ApiErrorModel
                {
                    Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                    Message = exception.Message,
                    Description = exception.StackTrace,
                    TraceId = context.TraceIdentifier,
                };
            }

            return exception switch
            {
                HumanReadableException humanReadableException => new HumanReadableErrorModel
                {
                    Code = context.Response.StatusCode.ToString(),
                    HumanReadableErrorMessage = humanReadableException.HumanReadableMessage,
                    Message = humanReadableException.Message,
                    TraceId = context.TraceIdentifier,
                },
                EntityNotFoundException => new ApiErrorModel
                {
                    Code = ((int)HttpStatusCode.NotFound).ToString(),
                    Message = "Сущность не была найдена.",
                    TraceId = context.TraceIdentifier,
                },
                _ => new ApiErrorModel
                {
                    Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                    Message = "Произошла непредвиденая ошибка.",
                    TraceId = context.TraceIdentifier,
                }
            };
        }

        private HttpStatusCode GetStatusCode(Exception exception)
        {
            return exception switch
            {
                EntityNotFoundException => HttpStatusCode.NotFound,
                EntitiesNotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}
