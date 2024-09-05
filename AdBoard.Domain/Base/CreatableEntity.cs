namespace AdBoard.Domain.Base;

/// <summary>
/// Базовая сущность с временем создания
/// </summary>
/// <typeparam name="TId">Тип данных идентификатора</typeparam>
public abstract class CreatableEntity<TId> : BaseEntity<TId>
{
    /// <summary>
    /// Дата создания сущности
    /// </summary>
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
