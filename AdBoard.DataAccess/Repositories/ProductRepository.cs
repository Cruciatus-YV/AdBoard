using AdBoard.AppServices.Contexts.Product.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.AppServices.Specifications;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Infrastructure.Extentions;
using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AdBoard.Contracts.Models.Entities.Product;
using AdBoard.Contracts.Models.Entities.Category.Responses;
using AdBoard.Contracts.Models.Entities.User.Responses;
using System.Linq.Dynamic.Core;
using AdBoard.Infrastructure;
using AdBoard.Infrastructure.Repositories;

namespace AdBoard.DataAccess.Repositories;

/// <summary>
/// Репозиторий, работающий с товарами.
/// </summary>
public class ProductRepository(AdBoardDbContext dbContext) : GenericRepository<ProductEntity, long>(dbContext), IProductRepository
{
    public async Task<ProductEntity?> GetByIdWithStore(long id, CancellationToken cancellationToken)
    {
        return await _asNoTracking.Include(x => x.Store).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public async Task<ProductEntity?> GetByIdWithImages(long id, CancellationToken cancellationToken)
    {
        return await _asNoTracking.Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteProductAsync(long id, CancellationToken cancellationToken)
    {
        var target = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status != ProductStatus.Unavailable, cancellationToken);

        if (target == null)
        {
            throw new NotFoundException("Cущность не найдена.");
        }

        target.Status = ProductStatus.Unavailable;
        target.UpdatedAt = DateTime.UtcNow;

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<(bool, IReadOnlyCollection<long>?)> UpdateProductCountAsync(IReadOnlyCollection<ProductRequestBuyable> buyableProducts,
                                                                                  CancellationToken cancellationToken)
    {
        var buyableProductsIds = buyableProducts.Select(x => x.Id).ToList();

        var targets = await _dbSet.Where(x => buyableProductsIds.Contains(x.Id) && x.Status == ProductStatus.Available)
                                  .ToListAsync(cancellationToken);

        List<long> conflictedProducts = [];

        foreach (var buyableProduct in buyableProducts)
        {
            var targetProduct = targets.FirstOrDefault(x => x.Id == buyableProduct.Id);

            if (targetProduct == null)
            {
                conflictedProducts.Add(buyableProduct.Id);
                continue;
            }

            if (targetProduct.Count + buyableProduct.Count < 0)
            {
                conflictedProducts.Add(buyableProduct.Id);
            }
            else
            {
                targetProduct.Count += buyableProduct.Count;
            }
            targetProduct.UpdatedAt = DateTime.UtcNow;
        }

        if (conflictedProducts.Count > 0)
        {
            return (false, conflictedProducts);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return (true, null);
    }

    public async Task<List<ProductPageItemDto>> GetProductsBySpecificationWithSortingAndPaginationAsync(ISpecification<ProductEntity> specification,
                                                                                                        string sortBy,
                                                                                                        bool ascending,
                                                                                                        int pageNumber,
                                                                                                        int pageSize,
                                                                                                        CancellationToken cancellationToken)
    {
        var query = _asNoTracking.Where(specification.PredicateExpression);

        var sortedQuery = IQueryableSortingExtention<ProductEntity>.ApplySorting(query, sortBy, ascending);

        var paginatedQuery = await sortedQuery.Select(x => new ProductPageItemDto
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price,
            MeasurementUnit = x.MeasurementUnit,
            Category = new CategoryResponseLight
            {
                Id = x.Category.Id,
                Name = x.Category.Name,
                ParentId = x.Category.ParentId,
                IsDeleted = x.Category.IsDeleted,
            },
            Count = x.Count,
            Status = x.Status,
            RatingSum = x.Feedback.Sum(x => x.Rating),
            FeedbackCount = x.Feedback.Count,
            StoreName = x.Store.Name,
            Images = x.Images.Select(p => p.Id).ToList(),

        }).PaginationListAsync(pageNumber, pageSize, cancellationToken);

        return paginatedQuery;
    }
    public async Task<ProductResponse?> GetFullInfoAsync(long id, CancellationToken cancellationToken)
    {
        var result = await _asNoTracking.Where(x => x.Id == id)
                                        .Select(x => new ProductResponse
                                        {
                                            Id = x.Id,
                                            Name = x.Name,
                                            Description = x.Description,
                                            Count = x.Count,
                                            Price = x.Price,
                                            MeasurementUnit = x.MeasurementUnit,
                                            Status = x.Status,
                                            Images = x.Images.Select(p => p.Id).ToList(),
                                            Store = new StoreResponse
                                            {
                                                Id = x.Store.Id,
                                                Name = x.Store.Name,
                                                Description = x.Store.Description,
                                                IsDefault = x.Store.IsDefault,
                                                Status = x.Store.Status,
                                                Seller = new UserLigthResponse(x.Store.Seller.Id, x.Store.Seller.FirstName, x.Store.Seller.LastName, x.Store.Seller.Email, x.Store.Seller.AvatarId)
                                            }
                                        }).FirstOrDefaultAsync(cancellationToken);

        return result;
    }
}
