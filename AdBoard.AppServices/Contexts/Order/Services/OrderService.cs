using AdBoard.AppServices.Contexts.Order.Repositories;
using AdBoard.AppServices.Contexts.OrderItem.Repositories;
using AdBoard.AppServices.Contexts.Product.Repositories;
using AdBoard.AppServices.Contexts.Product.Services;
using AdBoard.AppServices.Exceptions;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Order.Requests;
using AdBoard.Contracts.Models.Entities.Order.Responses;
using AdBoard.Contracts.Models.Entities.User;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Order.Services;

/// <summary>
/// Сервис для работы с заказами.
/// </summary>
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductService _productService;
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderService(IOrderRepository orderRepository, IProductService productService, IOrderItemRepository orderItemRepository)
    {
        _orderRepository = orderRepository;
        _productService = productService;
        _orderItemRepository = orderItemRepository;
    }

    public async Task AddAsync(OrderCreateRequest request, UserContextLight userContext, CancellationToken cancellationToken)
    {
        var product = await _productService.GetFullInfoAsync(request.ProductId, cancellationToken);
        
        if (product == null) 
        {
            throw new NotFoundException("Товар не найден");
        }
        
        if (product.Status != ProductStatus.Available) 
        {
            throw new Exception("Товар недоступен");
        }

        if (product.Count < request.Count)
        {
            throw new Exception("Недостаточно товара");
        }

        var order = await _orderRepository.GetByStoreIdWithItemsAsync(request.ProductId, cancellationToken);

        if (order == null || order.Status != OrderStatus.Draft) 
        {
            order = new OrderEntity
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ConsumerId = userContext.Id,
                Status = OrderStatus.Draft,
                StoreId = product.Store.Id,
                
            };

            order.Id = await _orderRepository.InsertAsync(order, cancellationToken);

        }

        var orderItem = new OrderItemEntity
        {
            Count = request.Count,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
            MeasurementUnit = product.MeasurementUnit,
            OrderId = order.Id,
            ProductId = product.Id,
            Status = OrderItemStatus.Ok,
            OrderPrice = product.Price,
        };

        if (order.OrderItems?.Any(x => x.ProductId == product.Id && x.Status == OrderItemStatus.Ok) == true)
        {
            order.OrderItems.First(x => x.ProductId == product.Id && x.Status == OrderItemStatus.Ok).Count += request.Count;
            order.OrderItems.First(x => x.ProductId == product.Id && x.Status == OrderItemStatus.Ok).UpdatedAt = DateTime.UtcNow;
        }
        else if (order.OrderItems?.Any() == true)
        {
            order.OrderItems.Add(orderItem);
        }
        else
        {
            order.OrderItems = [orderItem];
        }

        await _orderRepository.UpdateAsync(order, cancellationToken);
    }

    public async Task<List<OrderInvalidItemResponse>> BuyAsync(List<long> orderIds, UserContextLight userContextLight, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetStoresWithOrdersAndProducts(orderIds, userContextLight.Id, cancellationToken);

        if (orders.Count != orderIds.Count)
        {
            return orderIds.Where(x => !orders.Select(o => o.Id).Contains(x)).Select(x => new OrderInvalidItemResponse()
            {
                Message = "Заказ не найден",
                OrderId = x,
            }).ToList();
        }

        var invalidOrderItems = new List<OrderInvalidItemResponse>();
        foreach (var order in orders)
        {
            foreach (var item in order.OrderItems)
            {
                if (item.Count > item.Product.Count)
                {
                    invalidOrderItems.Add(new OrderInvalidItemResponse()
                    {
                        Message = $"Товаров на складе {item.Product.Count}, в заказе {item.Count}",
                        OrderId = item.OrderId,
                        OrderItemId = item.Id,
                    });
                }
                else
                {
                    item.Product.Count -= item.Count;
                    item.Status = OrderItemStatus.Payed;
                    item.IsDeleted = true;
                    item.UpdatedAt = DateTime.UtcNow;
                }
            }
            order.Status = OrderStatus.Payed;
            order.UpdatedAt = DateTime.UtcNow;
        }

        if (invalidOrderItems.Any())
        {
            return invalidOrderItems;
        }

        //Здесь должная быть оплата

        await _orderRepository.UpdateListAsync(orders, cancellationToken);

        return null;
    }

    public async Task UpdateCountAsync(long id, double count, UserContextLight userContext, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.GetByPredicate(x => x.Id == id && x.Order.ConsumerId == userContext.Id, cancellationToken);

        if (orderItem == null) 
        { 
            throw new NotFoundException("Запись не найдена");
        }

        var product = await _productService.GetFullInfoAsync(orderItem.ProductId, cancellationToken);

        if (product == null)
        {
            throw new NotFoundException("Товар не найден");
        }

        if (product.Status != ProductStatus.Available)
        {
            throw new Exception("Товар недоступен");
        }

        if (product.Count < count)
        {
            throw new Exception("Недостаточно товара");
        }

        orderItem.Count = count;
        orderItem.UpdatedAt = DateTime.UtcNow;

        await _orderItemRepository.UpdateAsync(orderItem, cancellationToken);
    }
}