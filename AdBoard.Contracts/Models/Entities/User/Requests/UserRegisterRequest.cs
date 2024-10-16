using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.User.Requests;

public class UserRegisterRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    [Required]
    public string LastName { get; set; }

    /// <summary>
    /// Дата рождения пользователя
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    [Required]
    public string Password { get; set; }

    public IFormFile? Avatar { get; set; }
}
