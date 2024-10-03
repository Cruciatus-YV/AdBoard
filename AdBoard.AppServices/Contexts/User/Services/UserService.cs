using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdBoard.AppServices.Contexts.User.Services;

public class UserService : IUserService
{
    private readonly UserManager<UserEntity> _userManager;

    public UserService(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserEntity> CreateUserAsync(UserRegisterRequest request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
        {
            throw new EmailAlredyRegisteredException("Пользователь с такой почтой уже зарегистрирован");
        }

        var user = new UserEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Birthday = request.Birthday,
            UserName = request.Email,
            NormalizedEmail = request.Email.ToLower(),
            NormalizedUserName = request.Email.ToLower(),
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new UnableCreateException(string.Join(", ", result.Errors.Select(error => error.Description)), "Не удалось создать пользователя");
        }

        return user;
    }

    public async Task<UserEntity?> GetUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<UserEntity?> GetUserByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }
}
