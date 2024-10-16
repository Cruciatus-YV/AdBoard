using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Category.Requests;

/// <summary>
/// DTO для представления обновлённой информации о категории.
/// </summary>
public class CategoryRequestUpdate
{
    /// <summary>
    /// Идентификатор категории, которую нужно обновить.
    /// Должен быть больше 0.
    /// </summary>
    [Required(ErrorMessage = "Идентификатор категории обязателен.")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор категории должен быть больше 0.")]
    public long Id { get; set; }

    /// <summary>
    /// Название категории.
    /// Должно содержать от 1 до 255 символов.
    /// </summary>
    [Required(ErrorMessage = "Название категории обязательно.")]
    [MaxLength(255, ErrorMessage = "Название категории не должно превышать 255 символов.")]
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор родительской категории.
    /// Если значение равно null, категория будет считаться корневой.
    /// </summary>
    public long? ParentId { get; set; }
}
