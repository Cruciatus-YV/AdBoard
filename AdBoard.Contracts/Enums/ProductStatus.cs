namespace AdBoard.Contracts.Enums;

/// <summary>
/// Статус товара.
/// </summary>
public enum ProductStatus
{
    /// <summary>
    /// Статус не определён.
    /// </summary>
    None = 0,

    /// <summary>
    /// Товар доступен для продажи и находится в производстве.
    /// </summary>
    Available = 1,

    /// <summary>
    /// Производство товара прекращено и товар больше не доступен.
    /// </summary>
    Unavailable = 2
}
