using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность категории товара.
/// </summary>
public class CategoryEntity : BaseEntity<long>
{
    /// <summary>
    /// Название категории.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор родительской категории.
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// Флаг удаления категории.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Статус одобрения создания категории
    /// </summary>
    public bool Approved { get; set; }

    /// <summary>
    /// Список продуктов категории.
    /// </summary>
    public virtual List<ProductEntity> Products { get; set; } = [];

    /// <summary>
    /// Подкатегории.
    /// </summary>
    public virtual List<CategoryEntity> ChildCategories { get; set; } = [];
}
