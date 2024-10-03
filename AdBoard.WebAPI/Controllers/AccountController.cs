using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;
using AdBoard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : AdBoardBaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            var result = await _accountService.RegisterAsync(request);

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
    }
}
