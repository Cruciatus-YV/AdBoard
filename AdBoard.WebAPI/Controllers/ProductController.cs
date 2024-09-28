using AdBoard.AppServices.Contexts.Product.Services;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("search")]
    public async Task<IActionResult> Search([FromBody] ProductRequestSearch request,
                                            CancellationToken cancellationToken)
    {
        var result = await _productService.GetByFilterAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _productService.GetFullInfoAsync(id, cancellationToken);
            return Ok(result);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(new
            {
                ex.Message,
                TraceId = HttpContext.TraceIdentifier
            });
        }
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ProductRequestCreate request,
                                            CancellationToken cancellationToken)
    {
        try
        {
            await _productService.CreateAsync(request, cancellationToken);
            return Created();
        }
        catch (NoneMeasurementUnitException ex)
        {
            return BadRequest(new
            {
                ex.Message,
                TraceId = HttpContext.TraceIdentifier
            });
        }
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] ProductRequestUpdate request,
                                        CancellationToken cancellationToken)
    {
        try
        {
            await _productService.UpdateAsync(request, cancellationToken);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(new
            {
                ex.Message,
                TraceId = HttpContext.TraceIdentifier
            });
        }
    }


    [HttpPatch("update-count")]
    public async Task<IActionResult> UpdateCount([FromBody] IReadOnlyCollection<ProductRequestBuyable> request,
                                                 CancellationToken cancellationToken)
    {
        try
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

            return Ok(new { Message = "Количество товара успешно обновлено." } );
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(new
            {
                ex.Message, 
                TraceId = HttpContext.TraceIdentifier
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        try
        {
            await _productService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(new
            {
                ex.Message,
                TraceId = HttpContext.TraceIdentifier
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
