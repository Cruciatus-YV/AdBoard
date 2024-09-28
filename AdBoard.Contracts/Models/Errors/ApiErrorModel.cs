﻿namespace AdBoard.Contracts.Models.Exceptions;

/// <summary>
/// Модель ошибки.
/// </summary>
public class ApiErrorModel
{
    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Описание ошибки.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Описание ошибки.
    /// </summary>
    public string TraceId { get; set; }

    /// <summary>
    /// Код ошибки.
    /// </summary>
    public string Code { get; set; }
}
