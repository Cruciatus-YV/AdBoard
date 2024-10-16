namespace AdBoard.Domain.Base;

/// <summary>
/// Базовая сущность с временем создания.
/// Наследует от <see cref="BaseEntity{TId}"/> и добавляет свойство для хранения даты создания сущности.
/// </summary>
/// <typeparam name="TId">Тип данных идентификатора сущности.</typeparam>
public abstract class CreatableEntity<TId> : BaseEntity<TId>
{
    /// <summary>
    /// Дата создания сущности.
    /// Значение устанавливается при создании и по умолчанию инициализируется текущим временем в UTC.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
