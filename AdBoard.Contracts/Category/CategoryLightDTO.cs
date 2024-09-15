namespace AdBoard.Contracts.Category;

/// <summary>
/// Модель категории для хлебных крошек. Есть Id, Name, IsDeleted и ParentId
/// </summary>
public class CategoryLightDTO
{
    /// <summary>
    /// Идентификатор категории
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Флаг удаления категории
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Идентификатор родительской категории
    /// </summary>
    public long? ParentId { get; set; }
}
