using AdBoard.Contracts.Enums;

namespace AdBoard.Contracts.Models.Entities.Store.Requests;

public class CreateStoreDTO
{
    /// <summary>
    /// Название магазина.
    /// Если флаг IsDefault в состоянии true, то ФИО пользователя станет названием магазина.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор продавца.
    /// </summary>
    public required string SellerId { get; set; }

    /// <summary>
    /// Описание магазина.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// По умолчанию при регистрации пользователя для него создаётся магазин с флагом IsDefault в состоянии true.
    /// Таким образом пользователь сможет продавать товар от своего имени
    /// У одного пользователя только один дефолтный магазин
    /// </summary>
    public bool IsDefault { get; set; }
}
