using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Category.Requests;

/// <summary>
/// Модель для создания новой категории.
/// </summary>
public class CategoryRequestCreate
{
    /// <summary>
    /// Название категории. Это обязательное поле.
    /// Должно содержать от 1 до 255 символов.
    /// </summary>
    [Required(ErrorMessage = "Название категории обязательно.")]
    [MaxLength(255, ErrorMessage = "Название категории не должно превышать 255 символов.")]
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор родительской категории.
    /// Если значение равно null, категория будет создана как корневая категория.
    /// </summary>
    public long? ParentId { get; set; }
}
