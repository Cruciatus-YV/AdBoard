using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.OrderItem.Repositories;

public interface IOrderItemRepository : IGenericRepository<OrderItemEntity, long>
{
}
