using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class StoreRepository(AdBoardDbContext _dbContext) : GenericRepository<StoreEntity, long>(_dbContext), IStoreRepository
{
    //public async Task<long> CreateAsync


    //create
    //get...
    //updateAdmin
    //updateStatus
}