using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;

namespace AdBoard.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService; 
        private readonly ITokenService _tokenService; 
        private readonly UserManager<UserEntity> _userManager; 

        public AccountService(IUserService userService, ITokenService tokenService, UserManager<UserEntity> userManager)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<string> RegisterAsync(UserRegisterRequest request)
        {
            var user = await _userService.CreateUserAsync(request);
            var token = await _tokenService.GenerateJwtToken(user!);
            return token; 
        }

        public async Task<string> LoginAsync(UserLoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) 
            { 
                throw new InvalidCredsException("Неверная почта или пароль.");
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (user == null || result == false)
            {
                throw new InvalidCredsException("Неверная почта или пароль.");
            }

            var token = await _tokenService.GenerateJwtToken(user);

            return token;
        }
    }
}
