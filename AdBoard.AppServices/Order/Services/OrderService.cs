using AdBoard.AppServices.Order.Repositories;

namespace AdBoard.AppServices.Order.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
}