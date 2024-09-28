using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Store.Repositories;

public interface IStoreRepository : IGenericRepository<StoreEntity, long>
{
}
