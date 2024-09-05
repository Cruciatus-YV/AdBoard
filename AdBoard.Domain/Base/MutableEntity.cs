namespace AdBoard.Domain.Base;

/// <summary>
/// Базовая сущность с временем создания и временем изменения
/// </summary>
/// <typeparam name="TId">Тип данных идентификатора</typeparam>
public abstract class MutableEntity<TId> : CreatableEntity<TId>
{
    /// <summary>
    /// Дата изменения сущности
    /// </summary>
    public required DateTime UpdatedAt { get; set; }
}
