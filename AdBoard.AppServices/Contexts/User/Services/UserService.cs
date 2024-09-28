using AdBoard.AppServices.Contexts.User.Repositories;

namespace AdBoard.AppServices.Contexts.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
}
