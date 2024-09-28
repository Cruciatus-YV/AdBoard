using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Product.Services;

public interface IProductService
{
    Task<List<ProductEntity>> GetByFilterAsync(ProductRequestSearch request,
                                               CancellationToken cancellationToken);

    Task<ProductResponse?> GetFullInfoAsync(long id, 
                                            CancellationToken cancellationToken);

    Task<long> CreateAsync(ProductRequestCreate request,
                           CancellationToken cancellationToken);

    Task<bool> UpdateAsync(ProductRequestUpdate request,
                           CancellationToken cancellationToken);

    Task<bool> DeleteAsync(long id,
                           CancellationToken cancellationToken);

    Task<(bool, IReadOnlyCollection<long>?)> UpdateCountAsync(IReadOnlyCollection<ProductRequestBuyable> request,
                                                              CancellationToken cancellationToken);
}
