using AdBoard.Contracts.Enums;
using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;

/// <summary>
/// Сущность магазина
/// </summary>
public class StoreEntity : MutableEntity<long>
{
    /// <summary>
    /// Название магазина
    /// Если флаг IsDefault в состоянии true, то ФИО пользователя станет названием магазина
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Идентификатор продавца
    /// </summary>
    public required string SellerId { get; set; }

    /// <summary>
    /// Описание магазина
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Статус магазина
    /// </summary>
    public required StoreStatus Status { get; set; }

    /// <summary>
    /// По умолчанию при регистрации пользователя для него создаётся магазин с флагом IsDefault в состоянии true
    /// Таким образом пользователь сможет продавать товар от своего имени
    /// У одного пользователя только один дефолтный магазин
    /// </summary>
    public bool IsDefault { get; set; }


    /// <summary>
    /// Ассортимент товаров
    /// </summary>
    public virtual List<ProductEntity> Products { get; set; }

    /// <summary>
    /// Продавец
    /// </summary>
    public virtual UserEntity Seller { get; set; }
}
