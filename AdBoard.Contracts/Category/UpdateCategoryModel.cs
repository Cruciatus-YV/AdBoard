namespace AdBoard.Contracts.Category;

/// <summary>
/// Модель для обновления категории. Есть Id, Name и ParentId
/// </summary>
public class UpdateCategoryModel
{
    public long Id { get; set; }
    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; }


    /// <summary>
    /// Идентификатор родительской категории
    /// </summary>
    public long? ParentId { get; set; }
}
