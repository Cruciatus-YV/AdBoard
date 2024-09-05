using AdBoard.Domain.Base;

namespace AdBoard.Domain.Entities;
/// <summary>
/// Сущность отзыва на купленный товар
/// </summary>
public class FeedbackEntity : CreatableEntity<long>
{
    /// <summary>
    /// Идентификатор автора отзыва
    /// </summary>
    public required string AuthorId { get; set; }
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public required string ProductId { get; set; }
    /// <summary>
    /// Отзыв
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    public required byte Rating { get; set; }


    /// <summary>
    /// Купленный товар
    /// </summary>
    public virtual ProductEntity Product { get; set; }
    /// <summary>
    /// Автор отзыва
    /// </summary>
    public virtual UserEntity Author { get; set; }

}
