using AdBoard.AppServices.Category.Services;
using AdBoard.Contracts.Category;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers;

/// <summary>
/// Контроллер API для управления категориями.
/// Используется для обработки HTTP-запросов, связанных с категориями, таких как создание, чтение, обновление и удаление.
/// Наследует от <see cref="ControllerBase"/> и использует атрибуты маршрутизации и API-контроллера.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Получает дерево категорий
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Статус-код 200 OK с деревом категорий</returns>
    [HttpGet("tree")]
    public async Task<IActionResult> GetTree(CancellationToken cancellationToken)
    {
        return Ok(await _categoryService.GetTreeAsync(cancellationToken));
    }

    /// <summary>
    /// Получает хлебные крошки для категории по её идентификатору
    /// </summary>
    /// <param name="id">Идентификатор категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Статус-код 200 OK с хлебными крошками</returns>
    [HttpGet("breadcrumbs/{id}")]
    public async Task<IActionResult> GetBreadcrumbs(long id, CancellationToken cancellationToken)
    {
        return Ok(await _categoryService.GetBreadcrumbsByIdAsync(id, cancellationToken));
    }

    /// <summary>
    /// Создает новую категорию
    /// </summary>
    /// <param name="model">Модель для создания категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Статус-код 201 Created</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryModel model, CancellationToken cancellationToken)
    {
        await _categoryService.CreateAsync(model, cancellationToken);
        return Created();
    }

    /// <summary>
    /// Обновляет информацию о категории
    /// </summary>
    /// <param name="model">Модель для обновления категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Статус-код 200 OK если категория обновлена, иначе 404 Not Found</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryModel model, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UpdateAsync(model, cancellationToken);
        return result ? Ok() : NotFound();
    }

    /// <summary>
    /// Удаляет категорию по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор категории</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Статус-код 200 OK если категория удалена, иначе 404 Not Found</returns>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var result = await _categoryService.DeleteAsync(id, cancellationToken);
        return result ? Ok() : NotFound();
    }
}
