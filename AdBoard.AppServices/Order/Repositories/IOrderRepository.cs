using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Order.Repositories;

public interface IOrderRepository : IGenericRepository<OrderEntity, long>
{
}
