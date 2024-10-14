using AdBoard.Contracts.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Store.Requests;

public class StoreRequestCreate
{
    /// <summary>
    /// Название магазина.
    /// Если флаг IsDefault в состоянии true, то ФИО пользователя станет названием магазина.
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Описание магазина.
    /// </summary>
    public string? Description { get; set; }

    public IFormFile? Avatar { get; set; }
}
