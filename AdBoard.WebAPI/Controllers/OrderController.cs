using AdBoard.AppServices.Contexts.Order.Services;
using AdBoard.Contracts.Models.Entities.Order.Requests;
using AdBoard.Contracts.Models.Entities.Order.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для управления заказами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : AdBoardBaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Создание заказа.
        /// </summary>
        /// <param name="request">Модель с данными для создания заказа.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Результат операции создания заказа.</returns>
        /// <response code="200">Заказ был успешно создан.</response>
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateRequest request, CancellationToken cancellationToken)
        {
            await _orderService.AddAsync(request, GetUserContextLigth(), cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Обновление количества товара в заказе.
        /// </summary>
        /// <param name="id">Идентификатор заказа.</param>
        /// <param name="count">Новое количество товара.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Результат операции обновления.</returns>
        /// <response code="200">Количество товара было успешно обновлено.</response>
        [HttpPut]
        public async Task<IActionResult> Update(long id, double count, CancellationToken cancellationToken)
        {
            await _orderService.UpdateCountAsync(id, count, GetUserContextLigth(), cancellationToken);

            return Ok();
        }

        /// <summary>
        /// Покупка товаров из списка заказов.
        /// </summary>
        /// <param name="orderIds">Список идентификаторов заказов.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Результат операции покупки. Если есть конфликты, вернется сообщение о них.</returns>
        /// <response code="200">Покупка прошла успешно.</response>
        /// <response code="400">Есть конфликтные товары.</response>
        [HttpPost("buy")]
        [ProducesResponseType(typeof(List<OrderInvalidItemResponse>), 400)]
        public async Task<IActionResult> Buy([FromBody] List<long> orderIds, CancellationToken cancellationToken)
        {
            var conflicts = await _orderService.BuyAsync(orderIds, GetUserContextLigth(), cancellationToken);

            return conflicts == null ? Ok() : BadRequest(conflicts);
        }
    }
}
