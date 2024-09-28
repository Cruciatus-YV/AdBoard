namespace AdBoard.Contracts.Models.Entities.Category.Responses;

/// <summary>
/// Модель DTO для представления категории.
/// </summary>
public class CategoryResponse
{
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название категории.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор родительской категории.
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// Список подкатегорий.
    /// </summary>
    public List<CategoryResponse> ChildCategories { get; set; } = [];
}
