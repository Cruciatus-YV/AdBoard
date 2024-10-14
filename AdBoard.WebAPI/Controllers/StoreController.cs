using AdBoard.AppServices.Contexts.Store.Services;
using AdBoard.Contracts.Models.Entities.Store.Requests;
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
    public class StoreController : AdBoardBaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StoreRequestCreate request, CancellationToken cancellationToken)
        {
            
            await _storeService.CreateAsync(request, GetUserContextLigth(), cancellationToken);

            return Created();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            var result = await _storeService.GetAsync(id, cancellationToken);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] StoreRequestUpdate request, CancellationToken cancellationToken)
        {
            await _storeService.UpdateAsync(request, GetUserContextLigth(), cancellationToken);

            return Ok();
        }
    }
}
