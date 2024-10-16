using Microsoft.AspNetCore.Identity;

namespace AdBoard.Domain.Entities;
/// <summary>
/// Сущность пользователя.
/// </summary>
public class UserEntity : IdentityUser
{
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Дата рождения пользователя.
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Идентификатор аватара пользователя.
    /// </summary>
    public long? AvatarId { get; set; }

    /// <summary>
    /// Аватар.
    /// </summary>
    public virtual FileEntity? Avatar { get; set; }

    /// <summary>
    /// Магазины, в которых работает пользователь.
    /// </summary>
    public virtual List<StoreEntity> Stores { get; set; }
}
