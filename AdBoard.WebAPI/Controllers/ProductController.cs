using AdBoard.AppServices.Contexts.Product.Services;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : AdBoardBaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("search")]
    public async Task<IActionResult> Search([FromBody] ProductRequestSearch request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetByFilterAsync(request, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var result = await _productService.GetFullInfoAsync(id, cancellationToken);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ProductRequestCreate request, CancellationToken cancellationToken)
    {
        await _productService.CreateAsync(request, GetUserContextLigth(), cancellationToken);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] ProductRequestUpdate request, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(request, cancellationToken);
        return Ok();
    }


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


    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(id, cancellationToken);
        return Ok();
    }

}
