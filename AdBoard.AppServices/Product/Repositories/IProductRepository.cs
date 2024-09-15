using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Product.Repositories;

public interface IProductRepository : IGenericRepository<ProductEntity, long>
{
}
