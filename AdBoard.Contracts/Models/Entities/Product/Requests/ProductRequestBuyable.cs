using AdBoard.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Product.Requests;

/// <summary>
/// DTO для представления информации о покупаемом товаре.
/// Содержит идентификатор товара и количество, доступное для покупки.
/// </summary>
public class ProductRequestBuyable
{
    /// <summary>
    /// Идентификатор покупаемого товара.
    /// </summary>
    [Required(ErrorMessage = "Идентификатор товара обязателен.")]
    public long Id { get; set; }

    /// <summary>
    /// Количество товара в наличии.
    /// Должно быть неотрицательным.
    /// </summary>
    [Required(ErrorMessage = "Количество товара обязательно.")]
    [Range(0, double.MaxValue, ErrorMessage = "Количество не должно быть отрицательным.")]
    public double Count { get; set; }
}
