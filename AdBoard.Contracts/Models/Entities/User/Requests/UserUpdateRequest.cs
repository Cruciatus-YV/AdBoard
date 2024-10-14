using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.User.Requests;

public class UserUpdateRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required]
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    [Required]
    public required string LastName { get; set; }

    /// <summary>
    /// Дата рождения пользователя
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    [Required]
    public string Email { get; set; }

    public IFormFile? Avatar { get; set; }
}
