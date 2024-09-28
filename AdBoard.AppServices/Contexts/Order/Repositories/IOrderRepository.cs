using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Order.Repositories;

public interface IOrderRepository : IGenericRepository<OrderEntity, long>
{
}
