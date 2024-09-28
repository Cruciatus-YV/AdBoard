namespace AdBoard.Domain.Base;

/// <summary>
/// Базовая сущность с временем создания и временем изменения.
/// Наследует от <see cref="CreatableEntity{TId}"/> и добавляет свойство для хранения даты последнего изменения сущности.
/// </summary>
/// <typeparam name="TId">Тип данных идентификатора сущности.</typeparam>
public abstract class MutableEntity<TId> : CreatableEntity<TId>
{
    /// <summary>
    /// Дата изменения сущности.
    /// Значение устанавливается при изменении и по умолчанию инициализируется текущим временем в UTC.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
