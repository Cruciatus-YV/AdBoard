using AdBoard.AppServices.Contexts.File.Services;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Contracts.Models.Entities.User.Requests;
using AdBoard.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using static System.Formats.Asn1.AsnWriter;

namespace AdBoard.AppServices.Contexts.User.Services;

public class UserService : IUserService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IFileService _fileService;

    public UserService(UserManager<UserEntity> userManager, IFileService fileService)
    {
        _userManager = userManager;
        _fileService = fileService;
    }

    public async Task<UserEntity> CreateUserAsync(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
        {
            throw new EmailAlredyRegisteredException("Пользователь с такой почтой уже зарегистрирован");
        }

        long? avatar = null;

        if (request.Avatar != null)
        {
            avatar = await _fileService.UploadAsync(request.Avatar, cancellationToken);
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
            AvatarId = avatar,
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

    public async Task<bool> UpdateAsync(UserUpdateRequest request, UserContextLight userContext, CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByIdAsync(userContext.Id);
        if (existingUser == null)
        {
            throw new NotFoundException("Пользователь не найден");
        }
        else 
        {
            var userByEmail = await _userManager.FindByEmailAsync(request.Email);
            if(userByEmail != null && userByEmail.Id != existingUser.Id)
            {
                throw new EmailAlredyRegisteredException("Пользователь с такой почтой уже зарегистрирован");
            }
        }

        long? avatar = null;

        if (request.Avatar != null)
        {
            if (existingUser.AvatarId.HasValue)
            {
                await _fileService.DeleteAsync(existingUser.AvatarId.Value, cancellationToken);
            }
            avatar = await _fileService.UploadAsync(request.Avatar, cancellationToken);
        }

        existingUser.FirstName = request.FirstName;
        existingUser.LastName = request.LastName;
        existingUser.Email = request.Email;
        existingUser.Birthday = request.Birthday;
        existingUser.UserName = request.Email;
        existingUser.NormalizedEmail = request.Email.ToLower();
        existingUser.NormalizedUserName = request.Email.ToLower();
        existingUser.AvatarId = avatar;

        var result = await _userManager.UpdateAsync(existingUser);
        if (!result.Succeeded)
        {
            throw new UnableCreateException(string.Join(", ", result.Errors.Select(error => error.Description)), "Не удалось создать пользователя");
        }

        return result.Succeeded;
    }
}
