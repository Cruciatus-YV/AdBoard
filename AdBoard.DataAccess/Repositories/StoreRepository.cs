using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User.Responses;
using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdBoard.Infrastructure.Repositories;

public class StoreRepository(AdBoardDbContext _dbContext) : GenericRepository<StoreEntity, long>(_dbContext), IStoreRepository
{
}