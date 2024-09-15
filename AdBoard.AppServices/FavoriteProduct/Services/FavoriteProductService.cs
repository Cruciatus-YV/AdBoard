using AdBoard.AppServices.FavoriteProduct.Repositories;

namespace AdBoard.AppServices.FavoriteProduct.Services;

public class FavoriteProductService : IFavoriteProductService
{
    private readonly IFavoriteProductRepository _favoriteProductReository;

    public FavoriteProductService(IFavoriteProductRepository favoriteProductReository)
    {
        _favoriteProductReository = favoriteProductReository;
    }
}