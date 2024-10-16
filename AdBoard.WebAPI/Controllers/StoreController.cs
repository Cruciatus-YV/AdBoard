using AdBoard.AppServices.Contexts.Store.Services;
using AdBoard.Contracts.Models.Entities.Product;
using AdBoard.Contracts.Models.Entities.Store.Requests;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер API для управления магазинами.
    /// Используется для обработки HTTP-запросов, связанных с магазинами, таких как создание, чтение, обновление и удаление.
    /// Наследует от <see cref="ControllerBase"/> и использует атрибуты маршрутизации и API-контроллера.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreController : AdBoardBaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        /// <summary>
        /// Создает новый магазин.
        /// </summary>
        /// <param name="request">Запрос с данными для создания магазина.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат создания магазина.</returns>
        /// <response code="201">Магазин был успешно создан.</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StoreRequestCreate request, CancellationToken cancellationToken)
        {
            await _storeService.CreateAsync(request, GetUserContextLigth(), cancellationToken);
            return Created();
        }

        /// <summary>
        /// Получает информацию о магазине по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор магазина.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Информация о магазине или 404, если магазин не найден.</returns>
        /// <response code="200">Магазин был успешно получен.</response>
        /// <response code="404">Магазин не найден.</response>
        [HttpGet("{id:long}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(StoreResponse), 200)]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            var result = await _storeService.GetAsync(id, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// Обновляет данные существующего магазина.
        /// </summary>
        /// <param name="request">Запрос с обновленными данными магазина.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Результат обновления магазина.</returns>
        /// <response code="200">Данные магазина успешно обновлены</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] StoreRequestUpdate request, CancellationToken cancellationToken)
        {
            await _storeService.UpdateAsync(request, GetUserContextLigth(), cancellationToken);
            return Ok();
        }
    }
}
