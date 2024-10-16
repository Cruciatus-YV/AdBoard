using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.FavoriteProduct.Repositories;

public interface IFavoriteProductRepository : IGenericRepository<FavoriteProductEntity, long>
{
}
