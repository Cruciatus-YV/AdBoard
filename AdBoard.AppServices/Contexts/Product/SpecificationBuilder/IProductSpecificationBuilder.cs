using AdBoard.AppServices.Specifications;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Product.SpecificationBuilder;

public interface IProductSpecificationBuilder
{
    /// <summary>
    /// Строит спецификацию по запросу.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <returns>Спецификация.</returns>
    ISpecification<ProductEntity> Build(ProductRequestSearch request);
}
