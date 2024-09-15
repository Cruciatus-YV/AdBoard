namespace AdBoard.Contracts.Category;

/// <summary>
/// Модель DTO для представления категории
/// </summary>
public class CategoryDTO
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
    /// Идентификатор родительской категории
    /// </summary>
    public long? ParentId { get; set; }


    /// <summary>
    /// Список подкатегорий
    /// </summary>
    public List<CategoryDTO> ChildCategories { get; set; } = [];
}
