namespace AdBoard.Contracts.Models.Entities.Category.Responses;

/// <summary>
/// Модель категории для представления хлебных крошек.
/// </summary>
public class CategoryResponseLight
{
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название категории.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Флаг удаления категории.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Идентификатор родительской категории.
    /// </summary>
    public long? ParentId { get; set; }
}
