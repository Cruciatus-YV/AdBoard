namespace AdBoard.Contracts.Models.Entities.Category.Requests;

/// <summary>
/// DTO для представления обновлённой информации о категории.
/// </summary>
public class CategoryRequestUpdate
{
    /// <summary>
    /// Идентификатор категории, которую нужно обновить.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название категории.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор родительской категории.
    /// Если значение равно null, категория будет считаться корневой.
    /// </summary>
    public long? ParentId { get; set; }
}
