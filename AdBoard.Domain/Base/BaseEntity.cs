namespace AdBoard.Domain.Base;

/// <summary>
/// Базовая сущность. Имеет только идентификатор.
/// </summary>
/// <typeparam name="TId">Тип данных идентификатора</typeparam>
public abstract class BaseEntity<TId>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public TId Id { get; set; }
}