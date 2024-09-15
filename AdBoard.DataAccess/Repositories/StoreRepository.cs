using AdBoard.AppServices.Store.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class StoreRepository(AdBoardDbContext _dbContext) : GenericRepository<StoreEntity, long>(_dbContext), IStoreRepository
{
}