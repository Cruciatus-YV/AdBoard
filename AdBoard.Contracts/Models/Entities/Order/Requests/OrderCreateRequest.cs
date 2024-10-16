using System.ComponentModel.DataAnnotations;

namespace AdBoard.Contracts.Models.Entities.Order.Requests;

/// <summary>
/// Представляет запрос на создание заказа.
/// </summary>
public class OrderCreateRequest
{
    /// <summary>
    /// Идентификатор продукта для заказа.
    /// Должен быть больше 0.
    /// </summary>
    [Required(ErrorMessage = "Идентификатор продукта обязателен.")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор продукта должен быть больше 0.")]
    public long ProductId { get; set; }

    /// <summary>
    /// Количество единиц продукта для заказа.
    /// Должно быть неотрицательным.
    /// </summary>
    [Required(ErrorMessage = "Количество продукта обязательно.")]
    [Range(0, double.MaxValue, ErrorMessage = "Количество должно быть неотрицательным.")]
    public double Count { get; set; }
}
