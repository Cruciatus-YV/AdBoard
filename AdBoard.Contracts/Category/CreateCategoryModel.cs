namespace AdBoard.Contracts.Category;

/// <summary>
/// Модель для создания категории. Есть Name и ParentId
/// </summary>
public class CreateCategoryModel
{
    /// <summary>
    /// Название категории
    /// </summary>
    public required string Name { get; set; }


    /// <summary>
    /// Идентификатор родительской категории
    /// </summary>
    public long? ParentId { get; set; }
}
