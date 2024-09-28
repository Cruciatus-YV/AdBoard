using AdBoard.AppServices.Contexts.OrderItem.Repositories;

namespace AdBoard.AppServices.Contexts.OrderItem.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }
}
