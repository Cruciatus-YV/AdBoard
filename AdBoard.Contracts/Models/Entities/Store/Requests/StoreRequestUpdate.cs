using AdBoard.Contracts.Enums;

namespace AdBoard.Contracts.Models.Entities.Store.Requests;

/// <summary>
/// DTO для представления обновленной информации о магазине.
/// </summary>
public class StoreRequestUpdate
{
    public long Id { get; set; }
    /// <summary>
    /// Название магазина.
    /// Если флаг IsDefault в состоянии true, то ФИО пользователя станет названием магазина.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Описание магазина.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Статус магазина.
    /// </summary>
    public required StoreStatus Status { get; set; }
}
