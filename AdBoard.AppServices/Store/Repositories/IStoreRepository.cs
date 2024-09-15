using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Store.Repositories;

public interface IStoreRepository : IGenericRepository<StoreEntity, long>
{
}
