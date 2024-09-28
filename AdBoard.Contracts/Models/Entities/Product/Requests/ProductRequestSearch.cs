using AdBoard.Contracts.Enums;

namespace AdBoard.Contracts.Models.Entities.Product.Requests;

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
    public int PageNumber { get; set; }

    /// <summary>
    /// Размер страницы — количество элементов на одной странице.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Поле, по которому осуществляется сортировка результатов.
    /// </summary>
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
