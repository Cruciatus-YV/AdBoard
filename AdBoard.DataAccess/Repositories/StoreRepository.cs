using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User.Responses;
using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdBoard.Infrastructure.Repositories;

/// <summary>
/// Репозиторий, работающий с магазинами.
/// </summary>
public class StoreRepository(AdBoardDbContext _dbContext) : GenericRepository<StoreEntity, long>(_dbContext), IStoreRepository
{
    public async Task<StoreResponse?> GetByIdWithSellerAsync(long id, CancellationToken cancellationToken)
    {
        return await _asNoTracking.Select(store => new StoreResponse
        {
            Description = store.Description,
            Id = store.Id,
            IsDefault = store.IsDefault,
            Name = store.Name,
            Status = store.Status,
            AvatarId = store.AvatarId,
            Seller = new UserLigthResponse(store.SellerId, store.Seller.FirstName, store.Seller.LastName, store.Seller.Email, store.Seller.AvatarId)
        }).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}