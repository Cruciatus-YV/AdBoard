using AdBoard.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Product.Requests;

/// <summary>
/// DTO для представления параметров поиска товаров.
/// Используется для фильтрации и сортировки списка товаров.
/// </summary>
public class ProductRequestSearch
{
    /// <summary>
    /// Поиск по строке.
    /// </summary>
    public string? SearchText { get; set; }

    /// <summary>
    /// Флаг поиска только по наименованию товара.
    /// </summary>
    public bool SearchOnlyByName { get; set; }

    /// <summary>
    /// Минимальная цена.
    /// </summary>
    public decimal? MinPrice { get; set; }

    /// <summary>
    /// Максимальная цена.
    /// </summary>
    public decimal? MaxPrice { get; set; }

    /// <summary>
    /// Единица измерения количества товара.
    /// </summary>
    public MeasurementUnit? MeasurementUnit { get; set; }

    /// <summary>
    /// Идентификатор категории товара.
    /// </summary>
    public long? CategoryId { get; set; }

    /// <summary>
    /// Минимальное количество товара в наличии.
    /// </summary>
    public double? MinCount { get; set; }

    /// <summary>
    /// Статус товара.
    /// </summary>
    public ProductStatus? Status { get; set; }

    /// <summary>
    /// Дата начала периода, в течение которого фильтруются данные.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Дата окончания периода, в течение которого фильтруются данные.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Номер страницы для пагинации результатов.
    /// </summary>
    [Required(ErrorMessage = "Номер страницы обязателен.")]
    [Range(1, int.MaxValue, ErrorMessage = "Номер страницы должен быть больше 0.")]
    public int PageNumber { get; set; }

    /// <summary>
    /// Размер страницы — количество элементов на одной странице.
    /// </summary>
    [Required(ErrorMessage = "Размер страницы обязателен.")]
    [Range(1, 100, ErrorMessage = "Размер страницы должен быть от 1 до 100.")]
    public int PageSize { get; set; }

    /// <summary>
    /// Поле, по которому осуществляется сортировка результатов.
    /// </summary>
    [Required(ErrorMessage = "Поле, по которому нужно осуществить сортировку, обязательно.")]
    public string SortBy { get; set; }

    /// <summary>
    /// Определяет порядок сортировки: true — по возрастанию, false — по убыванию.
    /// </summary>
    public bool IsAsc { get; set; }

    /// <summary>
    /// Идентификаторы магазинов.
    /// </summary>
    public List<long>? StoreIds { get; set; }
}
