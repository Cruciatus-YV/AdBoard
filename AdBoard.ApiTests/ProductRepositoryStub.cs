using AdBoard.AppServices.Contexts.Product.Repositories;
using AdBoard.AppServices.Specifications;
using AdBoard.Contracts.Enums;
using AdBoard.Contracts.Models.Entities.Product;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.Contracts.Models.Entities.Store.Responses;
using AdBoard.Contracts.Models.Entities.User.Responses;
using AdBoard.Domain.Entities;
using System.Linq.Expressions;

namespace AdBoard.ApiTests;

public class ProductRepositoryStub : IProductRepository
{
    public Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteListAsync(IReadOnlyCollection<long> ids, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity?> GetByIdWithImages(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity?> GetByPredicate(Expression<Func<ProductEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductEntity>> GetByPredicateAndPaginationAsync(Expression<Func<ProductEntity, bool>> predicate, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponse?> GetFullInfoAsync(long id, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new ProductResponse
        {
            Id = 0,
            Count = 0,
            Description = "stub_productDescription",
            Name = "stub_productName",
            Price = 0,
            Status = ProductStatus.None,
            MeasurementUnit = MeasurementUnit.None,
            Images = new List<long>(),
            Store = new StoreResponse
            {
                Id = 0,
                Name = "stub_storeName",
                AvatarId = 0,
                Description = "stub_storeDescription",
                IsDefault = false,
                Status = StoreStatus.None,
                Seller = new UserLigthResponse(Guid.Empty.ToString(), "stub_sellerFirstName", "stub_sellerLastName", "stub_sellerEmail", 0),
            }
        });
    }

    public Task<List<ProductEntity>> GetListByPredicate(Expression<Func<ProductEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductPageItemDto>> GetProductsBySpecificationWithSortingAndPaginationAsync(ISpecification<ProductEntity> specification, string sortBy, bool ascending, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertAsync(ProductEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductEntity>> InsertListAsync(IReadOnlyCollection<ProductEntity> entities, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProductEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateListAsync(IReadOnlyCollection<ProductEntity> entities, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<(bool, IReadOnlyCollection<long>?)> UpdateProductCountAsync(IReadOnlyCollection<ProductRequestBuyable> buyableProducts, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
