using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.Contracts.Models.Entities.User.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers
{
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

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] UserRegisterRequest request, CancellationToken cancellationToken)
        {
            var result = await _accountService.RegisterAsync(request, cancellationToken);

            return Ok(new { message = "Регистрация успешна" });
        }

        [HttpPost("login")]
        [AllowAnonymous]
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

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            await _userService.UpdateAsync(request, GetUserContextLigth(), cancellationToken);

            return Ok();
        }
    }
}
