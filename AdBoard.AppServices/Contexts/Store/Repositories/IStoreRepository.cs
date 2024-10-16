using AdBoard.AppServices.GenericRepository;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Store.Repositories;

public interface IStoreRepository : IGenericRepository<StoreEntity, long>
{
    Task<StoreResponse?> GetByIdWithSellerAsync(long id, CancellationToken cancellationToken);
}
