using AdBoard.AppServices.Order.Repositories;
using AdBoard.AppServices.User.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class UserRepository(AdBoardDbContext _dbContext) : GenericRepository<UserEntity, string>(_dbContext), IUserRepository
{
}