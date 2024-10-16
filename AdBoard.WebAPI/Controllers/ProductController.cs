using AdBoard.AppServices.Contexts.Product.Services;
using AdBoard.Contracts.Models.Entities.Product;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для управления продуктами в приложении.
/// Позволяет выполнять операции поиска, создания, обновления, удаления и обновления количества товаров.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : AdBoardBaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Поиск продуктов по заданным критериям.
    /// </summary>
    /// <param name="request">Запрос с параметрами для поиска.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Результаты поиска продуктов.</returns>
    /// <response code="200">Поиск товара произведён успешно.</response>
    [HttpPost("search")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<ProductPageItemDto>), 200)]
    public async Task<IActionResult> Search([FromBody] ProductRequestSearch request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetByFilterAsync(request, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение информации о продукте по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о продукте.</returns>
    /// <response code="200">Товар был успешно получен.</response>
    [HttpGet("{id:long}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ProductResponse), 200)]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var result = await _productService.GetFullInfoAsync(id, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Создание продукта.
    /// </summary>
    /// <param name="request">Запрос с данными для создания продукта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Результат создания продукта.</returns>
    /// <response code="201">Товар был успешно создан.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ProductRequestCreate request, CancellationToken cancellationToken)
    {
        await _productService.CreateAsync(request, GetUserContextLigth(), cancellationToken);
        return Created();
    }

    /// <summary>
    /// Обновление данных о продукте.
    /// </summary>
    /// <param name="request">Запрос с обновленными данными продукта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Результат обновления продукта.</returns>
    /// <response code="200">Товар был успешно обновлён.</response>
    [HttpPut]
    public async Task<IActionResult> Update([FromForm] ProductRequestUpdate request, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(request, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Обновление количества продуктов.
    /// </summary>
    /// <param name="request">Запрос с идентификаторами продуктов и необходимым количеством товара.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Результат обновления количества продуктов.</returns>
    /// <response code="200">Количество товара было успешно обновлено.</response>
    /// <response code="409">Обновление невозможно: есть конфликтные товары.</response>
    /// <response code="400">Запрос пуст или содержит неверные данные.</response>
    [HttpPatch("update-count")]
    public async Task<IActionResult> UpdateCount([FromBody] IReadOnlyCollection<ProductRequestBuyable> request, CancellationToken cancellationToken)
    {
        if (request == null || !request.Any())
        {
            return BadRequest(new { Message = "Запрос пуст или содержит неверные данные." });
        }

        var (success, conflictedProducts) = await _productService.UpdateCountAsync(request, cancellationToken);

        if (!success && conflictedProducts != null)
        {
            return Conflict(new
            {
                Message = "Обновление невозможно: есть конфликтные товары.",
                ConflictedProductIds = conflictedProducts
            });
        }

        return Ok(new { Message = "Количество товара успешно обновлено." });
    }

    /// <summary>
    /// Помечает товар как удалённый по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Результат удаления продукта.</returns>
    /// <response code="200">Товар был успешно помечен как удалённый.</response>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}
