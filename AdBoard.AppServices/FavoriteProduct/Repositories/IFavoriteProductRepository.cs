using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.FavoriteProduct.Repositories;

public interface IFavoriteProductRepository : IGenericRepository<FavoriteProductEntity, long>
{
}
