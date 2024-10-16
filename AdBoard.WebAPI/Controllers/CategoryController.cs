using AdBoard.AppServices.Contexts.Category.Services;
using AdBoard.Contracts.Models.Entities.Category.Requests;
using AdBoard.Contracts.Models.Entities.Category.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AdBoard.WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с категориями.
/// Используется для обработки HTTP-запросов, связанных с категориями, таких как создание, чтение, обновление и удаление.
/// Наследует от <see cref="ControllerBase"/> и использует атрибуты маршрутизации и API-контроллера.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoryController : AdBoardBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Получение дерева категорий.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус-код 200 OK с деревом категорий.</returns>
    /// <response code="200">Успешно возвращено дерево категорий.</response>
    [HttpGet("tree")]
    [ProducesResponseType(typeof(IReadOnlyCollection<CategoryResponse>), (int)HttpStatusCode.OK)]

    public async Task<IActionResult> GetTree(CancellationToken cancellationToken)
    {
        return Ok(await _categoryService.GetTreeAsync(cancellationToken));
    }

    /// <summary>
    /// Получение хлебных крошки для категории по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус-код 200 OK с хлебными крошками.</returns>
    /// <response code="200">Успешно возвращены хлебные крошки.</response>
    /// <response code="404">Категория не найдена.</response>
    [HttpGet("breadcrumbs/{id}")]
    [ProducesResponseType(typeof(List<CategoryResponseLight>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBreadcrumbs(long id, CancellationToken cancellationToken)
    {
        var breadcrumbs = await _categoryService.GetBreadcrumbsByIdAsync(id, cancellationToken);
        return breadcrumbs != null ? Ok(breadcrumbs) : NotFound();
    }

    /// <summary>
    /// Заявка на создание категории.
    /// </summary>
    /// <param name="request">Модель для создания категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус-код 201 Created.</returns>
    /// <response code="201">Категория успешно создана.</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]

    public async Task<IActionResult> ProposeToCreate([FromBody] CategoryRequestCreate request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.CreateUnapprovedAsync(request, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    /// <summary>
    /// Подтверждение создания категории по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор подтверждаемой категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус-код 200 OK с сообщением об одобрении.</returns>
    /// <response code="200">Категория была одобрена и создана.</response>
    /// <response code="404">Категория не найдена.</response>
    [HttpPatch("approve")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> Approve(long id, CancellationToken cancellationToken)
    {
        var exists = await _categoryService.ApproveAsync(id, cancellationToken);
        if (!exists) return NotFound();

        return Ok(new { Message = "Категория была одобрена и создана." });
    }

    /// <summary>
    /// Обновляет информацию о категории.
    /// </summary>
    /// <param name="request">Модель для обновления категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус-код 200 OK если категория обновлена, иначе 404 Not Found.</returns>
    /// <response code="200">Категория успешно обновлена.</response>
    /// <response code="404">Категория не найдена.</response>
    [HttpPut]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> Update([FromBody] CategoryRequestUpdate request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.UpdateAsync(request, cancellationToken);
        return result ? Ok() : NotFound();
    }

    /// <summary>
    /// Удаляет категорию по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Статус-код 200 OK если категория удалена, иначе 404 Not Found.</returns>
    /// <response code="200">Категория успешно удалена.</response>
    /// <response code="404">Категория не найдена.</response>
    [HttpDelete("{id:long}")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var result = await _categoryService.DeleteAsync(id, cancellationToken);
        return result ? Ok() : NotFound();
    }
}
