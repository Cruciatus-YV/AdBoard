namespace AdBoard.Contracts.Enums;

/// <summary>
/// Статус товара
/// </summary>
public enum ProductStatus
{
    /// <summary>
    /// Статус не определён
    /// </summary>
    None = 0,

    /// <summary>
    /// Производство товара продолжается
    /// </summary>
    Available = 1,

    /// <summary>
    /// Производство товара прекращено
    /// </summary>
    Unavailable = 2,

}
