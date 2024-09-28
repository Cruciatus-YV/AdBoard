using AdBoard.AppServices.Contexts.Order.Repositories;

namespace AdBoard.AppServices.Contexts.Order.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
}