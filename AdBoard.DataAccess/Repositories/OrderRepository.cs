using AdBoard.AppServices.Contexts.Order.Repositories;
using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdBoard.Infrastructure.Repositories;

/// <summary>
/// Репозиторий, работающий с заказами.
/// </summary>
public class OrderRepository(AdBoardDbContext _dbContext) : GenericRepository<OrderEntity, long>(_dbContext), IOrderRepository
{
    public async Task<OrderEntity?> GetByStoreIdWithItemsAsync(long id, CancellationToken cancellationToken)
    {
        return await _asNoTracking.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.StoreId == id, cancellationToken);
    }

    public async Task<List<OrderEntity>> GetStoresWithOrdersAndProducts(IReadOnlyCollection<long> orderIds, string userId, CancellationToken cancellationToken)
    {
        return await _asNoTracking.Include(x => x.OrderItems).Where(x => orderIds.Contains(x.Id) && x.ConsumerId == userId).Select(x => new OrderEntity()
        {
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
            ConsumerId = x.ConsumerId,
            Id = x.Id,
            Status = x.Status,
            StoreId = x.StoreId,
            OrderItems = x.OrderItems.Select(o => new OrderItemEntity()
            {
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
                Count = o.Count,
                Id = o.Id,
                IsDeleted = o.IsDeleted,
                MeasurementUnit = o.MeasurementUnit,
                OrderId = o.OrderId,
                OrderPrice = o.OrderPrice,
                ProductId = o.ProductId,
                Status = o.Status,
                Product = o.Product,
            }).ToList(),
        }).ToListAsync(cancellationToken);
    }
}