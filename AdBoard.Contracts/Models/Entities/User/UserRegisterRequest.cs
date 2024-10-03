namespace AdBoard.Contracts.Models.Entities.User;

public class UserRegisterRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Дата рождения пользователя
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; }
}
