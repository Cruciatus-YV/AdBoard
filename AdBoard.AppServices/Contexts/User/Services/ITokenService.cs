using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.User.Services;

public interface ITokenService
{
    Task<string> GenerateJwtToken(UserEntity user);
}
