using AdBoard.Contracts.Models.Exceptions;

/// <summary>
/// Модель человеко-читаемой ошибки.
/// </summary>
public class HumanReadableErrorModel : ApiErrorModel
{
    /// <summary>
    /// Человеко-читаемое сообщение об ошибке для пользователя.
    /// </summary>
    public string HumanReadableErrorMessage { get; init; }
}