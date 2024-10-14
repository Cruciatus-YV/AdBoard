using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.ProductImage.Repositories;

public interface IProductImageRepository : IGenericRepository<ProductImageEntity, long>
{
}
