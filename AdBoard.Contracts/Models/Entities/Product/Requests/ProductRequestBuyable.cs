using AdBoard.Contracts.Enums;

namespace AdBoard.Contracts.Models.Entities.Product.Requests;

/// <summary>
/// DTO для представления информации о покупаемом товаре.
/// </summary>
public class ProductRequestBuyable
{
    /// <summary>
    /// Идентификатор покупаемого товара.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Количество товара в наличии.
    /// </summary>
    public double Count { get; set; }
}
