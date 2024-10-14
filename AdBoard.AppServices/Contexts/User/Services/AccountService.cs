using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Contracts.Models.Entities.User.Requests;
using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;
using System.Threading;

namespace AdBoard.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService; 
        private readonly ITokenService _tokenService; 
        private readonly UserManager<UserEntity> _userManager; 
        private readonly IStoreRepository _storeRepository;

        public AccountService(IUserService userService, ITokenService tokenService, UserManager<UserEntity> userManager, IStoreRepository storeRepository)
        {
            _userService = userService;
            _tokenService = tokenService;
            _userManager = userManager;
            _storeRepository = storeRepository;
        }

        public async Task<string> RegisterAsync(UserRegisterRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.CreateUserAsync(request, cancellationToken);

            var entity = new StoreEntity
            {
                Name = $"{user.FirstName} {user.LastName}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Description = null,
                IsDefault = true,
                SellerId = user.Id,
                Status = StoreStatus.Available,
            };
            await _storeRepository.InsertAsync(entity, cancellationToken);

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
