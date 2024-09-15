using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.User.Repositories;

public interface IUserRepository : IGenericRepository<UserEntity, string>
{
}
