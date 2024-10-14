using System.ComponentModel.DataAnnotations;
using AdBoard.Contracts.Enums;
using Microsoft.AspNetCore.Http;

namespace AdBoard.Contracts.Models.Entities.Product.Requests;

/// <summary>
/// DTO для представления информации о создаваемом товаре.
/// </summary>
public class ProductRequestCreate
{
    /// <summary>
    /// Наименование товара.
    /// </summary>
    [Required(ErrorMessage = "Наименование товара обязательно для заполнения.")]
    [StringLength(100, ErrorMessage = "Наименование товара не может превышать 100 символов.")]
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор магазина.
    /// </summary>
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор магазина должен быть положительным числом.")]
    public long StoreId { get; set; }

    /// <summary>
    /// Идентификатор категории товара.
    /// </summary>
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор категории должен быть положительным числом.")]
    public long CategoryId { get; set; }

    /// <summary>
    /// Описание товара.
    /// </summary>
    [StringLength(500, ErrorMessage = "Описание товара не может превышать 500 символов.")]
    public string? Description { get; set; }

    /// <summary>
    /// Цена товара.
    /// </summary>
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена товара должна быть положительным числом.")]
    public decimal Price { get; set; }

    /// <summary>
    /// Количество товара в наличии.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "Количество товара не может быть отрицательным.")]
    public double Count { get; set; }

    /// <summary>
    /// Единица измерения количества товара.
    /// </summary>
    public MeasurementUnit MeasurementUnit { get; set; }

    public IFormFileCollection? Images { get; set; }
}
