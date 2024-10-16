using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Order.Repositories;

public interface IOrderRepository : IGenericRepository<OrderEntity, long>
{
    Task<OrderEntity?> GetByStoreIdWithItemsAsync(long id, CancellationToken cancellationToken);

    Task<List<OrderEntity>> GetStoresWithOrdersAndProducts(IReadOnlyCollection<long> orderIds, string userId, CancellationToken cancellationToken);
}
