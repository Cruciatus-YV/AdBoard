using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.User.Repositories;

public interface IUserRepository : IGenericRepository<UserEntity, string>
{
}
