using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.Contracts.Models.Entities.User.Requests;
using AdBoard.Contracts.Models.Entities.User.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace AdBoard.WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для работы с учетными записями пользователей.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : AdBoardBaseController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        /// <summary>
        /// Регистрация нового пользователя.
        /// </summary>
        /// <param name="request">Данные для регистрации пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Результат операции регистрации.</returns>
        /// <response code="200">Регистрация успешна.</response>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserRegisterRequest request, CancellationToken cancellationToken)
        {
            var result = await _accountService.RegisterAsync(request, cancellationToken);
            return Ok(new { message = "Регистрация успешна" });
        }

        /// <summary>
        /// Вход пользователя в систему.
        /// </summary>
        /// <param name="request">Данные для входа пользователя.</param>
        /// <returns>Токен авторизации пользователя.</returns>
        /// <response code="200">Авторизация успешна.</response>
        /// <response code="401">Ошибка авторизации.</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            try
            {
                var token = await _accountService.LoginAsync(request);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Получение информации о пользователе по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Информация о пользователе.</returns>
        /// <response code="200">Информация о пользователе получена.</response>
        /// <response code="404">Пользователь не найден.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserLigthResponse), 200)]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user != null ? Ok(user) : NotFound();
        }

        /// <summary>
        /// Обновление данных пользователя.
        /// </summary>
        /// <param name="request">Данные для обновления пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Результат операции обновления данных пользователя.</returns>
        /// <response code="200">Информация о пользователе обновлена.</response>
        /// <response code="404">Пользователь не найден.</response>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            var updated = await _userService.UpdateAsync(request, GetUserContextLigth(), cancellationToken);
            return updated ? Ok() : NotFound();
        }
    }
}
