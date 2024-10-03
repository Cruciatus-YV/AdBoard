using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Category.Responses;

namespace AdBoard.Contracts.Models.Entities.Product;

public class ProductPageItemDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
    public CategoryResponseLight Category { get; set; }
    public double Count { get; set; }
    public ProductStatus Status { get; set; }
    public int RatingSum { get; set; }
    public int FeedbackCount { get; set; }
    public string StoreName { get; set; }
}
