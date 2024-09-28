namespace AdBoard.Domain.Base;

/// <summary>
/// Базовый класс для сущностей, содержащий только идентификатор.
/// Используется для обеспечения общей структуры всех сущностей в доменной модели.
/// </summary>
/// <typeparam name="TId">Тип данных идентификатора сущности.</typeparam>
public abstract class BaseEntity<TId>
{
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    public TId Id { get; set; }
}
