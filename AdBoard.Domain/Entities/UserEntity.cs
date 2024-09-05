using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность пользователя
/// </summary>
public sealed class UserEntity : BaseEntity<string>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly Birthday { get; set; }
}
