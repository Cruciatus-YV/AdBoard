using AdBoard.AppServices.OrderItem.Repositories;

namespace AdBoard.AppServices.OrderItem.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }
}
