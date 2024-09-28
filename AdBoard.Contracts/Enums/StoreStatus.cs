namespace AdBoard.Contracts.Enums;

/// <summary>
/// Статус магазина.
/// </summary>
public enum StoreStatus
{
    /// <summary>
    /// Статус магазина не определён.
    /// </summary>
    None = 0,

    /// <summary>
    /// Магазин открыт и функционирует.
    /// </summary>
    Available = 1,

    /// <summary>
    /// Магазин закрыт и не работает.
    /// </summary>
    Unavailable = 2,

    /// <summary>
    /// Магазин забанен.
    /// </summary>
    Banned = 3,

    /// <summary>
    /// Магазин временно не работает
    /// </summary>
    TemporarilyUnavailable = 4,
}
