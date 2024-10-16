using AdBoard.Contracts.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Product.Requests;

/// <summary>
/// DTO для представления обновлённой информации о товаре.
/// Используется для передачи данных о товаре при его обновлении.
/// </summary>
public class ProductRequestUpdate
{
    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Наименование товара.
    /// Максимальная длина 255 символов.
    /// </summary>
    [MaxLength(255)]
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор категории товара.
    /// </summary>
    public long CategoryId { get; set; }

    /// <summary>
    /// Описание товара.
    /// Максимальная длина 1000 символов.
    /// </summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// Цена товара.
    /// Должна быть неотрицательной.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "Цена не должна быть отрицательной.")]
    public decimal Price { get; set; }

    /// <summary>
    /// Количество товара в наличии.
    /// Должно быть неотрицательным.
    /// </summary>
    [Range(double.MinValue, double.MaxValue, ErrorMessage = "Такое количество не предусмотрено.")]
    public double Count { get; set; }

    /// <summary>
    /// Единица измерения количества товара.
    /// </summary>
    public MeasurementUnit MeasurementUnit { get; set; }

    /// <summary>
    /// Статус товара.
    /// </summary>
    public ProductStatus Status { get; set; }

    /// <summary>
    /// Коллекция изображений товара.
    /// </summary>
    public IFormFileCollection? Images { get; set; }

    /// <summary>
    /// Список идентификаторов изображений, которые должны быть удалены.
    /// </summary>
    public List<long>? DeletedImages { get; set; }
}
