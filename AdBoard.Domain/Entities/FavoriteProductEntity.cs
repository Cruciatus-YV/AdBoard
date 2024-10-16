using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность связи пользователя с понравившимся товаром.
/// </summary>
public class FavoriteProductEntity : CreatableEntity<long>
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Идентификатор понравившегося товара.
    /// </summary>
    public required long ProductId { get; set; }

    /// <summary>
    /// Понравившийся товар.
    /// </summary>
    public virtual ProductEntity Product { get; set; }
}
