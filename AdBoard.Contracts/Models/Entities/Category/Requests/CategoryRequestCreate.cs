using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Category.Requests;

/// <summary>
/// Модель для создания новой категории.
/// </summary>
public class CategoryRequestCreate
{
    /// <summary>
    /// Название категории. Это обязательное поле.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор родительской категории.
    /// Если значение равно null, категория будет создана как корневая категория.
    /// </summary>
    public long? ParentId { get; set; }
}
