using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Exceptions;
using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using NotFoundException = AdBoard.AppServices.Exceptions.NotFoundException;

namespace AdBoard.WebAPI.Middlewares
{
    /// <summary>
    /// Промежуточное ПО для обработки ошибок.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
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
            catch (Exception exeption)
            {
                var logger = serviceProvider.GetService<ILogger<ExceptionHandlingMiddleware>>();
                logger?.LogError(exeption, "Произошла ошибка: {ErrorMessage}", exeption.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)GetStatusCode(exeption);

                var apiError = CreateApiError(exeption, context, environment);
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
                    Description = exception.StackTrace ?? "Стек вызовов недоступен.",
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
                _ => new ApiErrorModel
                {
                    Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                    Message = "Произошла непредвиденная ошибка.",
                    TraceId = context.TraceIdentifier,
                }
            };
        }


        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All),
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private HttpStatusCode GetStatusCode(Exception exception)
        {
            return exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                EmailAlredyRegisteredException => HttpStatusCode.Conflict,
                NoneMeasurementUnitException => HttpStatusCode.BadRequest,
                InvalidCredsException => HttpStatusCode.BadRequest,
                AccessDeniedException => HttpStatusCode.Forbidden,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}
