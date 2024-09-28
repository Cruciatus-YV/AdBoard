using Abp.Extensions;
using Abp.Timing;
using AdBoard.AppServices.Specifications;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Product.SpecificationBuilder;

public class ProductSpecificationBuilder : IProductSpecificationBuilder
{
    public ISpecification<ProductEntity> Build(ProductRequestSearch request)
    {
        var specification = Specification<ProductEntity>.FromPredicate(new SpecificationByStatus<ProductEntity>(request.Status));

        specification = specification.And(new SpecificationByPrice<ProductEntity>(request.MinPrice, request.MaxPrice, request.MeasurementUnit));

        if (request.CategoryId.HasValue)
            specification = specification.And(new SpecificationByCategory<ProductEntity>(request.CategoryId.Value));

        if (!request.SearchText.IsNullOrWhiteSpace())
            specification = specification.And(new SpecificationBySearchString<ProductEntity>(request.SearchText!, request.SearchOnlyByName));

        if (request.StoreIds?.Any() == true)
            specification = specification.And(new SpecificationByStores<ProductEntity>(request.StoreIds));

        if (request.MinCount.HasValue)
            specification = specification.And(new SpecificationByMinCount<ProductEntity>(request.MinCount.Value));

        if (request.StartDate.HasValue && request.EndDate.HasValue)
            specification = specification.And(new SpecificationByDateOfCreating<ProductEntity>(new DateTimeRange(request.StartDate.Value, request.EndDate.Value)));

        return specification;
    }
}
