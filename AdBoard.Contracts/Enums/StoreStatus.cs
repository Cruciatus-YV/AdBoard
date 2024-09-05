namespace AdBoard.Contracts.Enums;

/// <summary>
/// Статус магазина
/// </summary>
public enum StoreStatus
{
    /// <summary>
    /// Статус не определён
    /// </summary>
    None = 0,
    /// <summary>
    /// Магазин функционирует
    /// </summary>
    Available = 1,
    /// <summary>
    /// Магазин закрыт
    /// </summary>
    Unavailable = 2,
}
