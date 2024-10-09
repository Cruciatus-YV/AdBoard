using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User.Responses;
using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdBoard.Infrastructure.Repositories;

public class StoreRepository(AdBoardDbContext _dbContext) : GenericRepository<StoreEntity, long>(_dbContext), IStoreRepository
{
    public async Task<StoreResponse?> GetStoreInfo(long id, CancellationToken cancellationToken)
    {
        var result = await _asNoTracking.Where(x => x.Id == id).Select(x => new StoreResponse
        {
            Description = x.Description,
            Id = x.Id,
            IsDefault = x.IsDefault,
            Name = x.Name,
            Status = x.Status,
            Seller = new UserLigthResponse(x.SellerId, x.Seller.FirstName, x.Seller.LastName, x.Seller.Email)
        }).FirstOrDefaultAsync(cancellationToken);

        return result;
    }
}