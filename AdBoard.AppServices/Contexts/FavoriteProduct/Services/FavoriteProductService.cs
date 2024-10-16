using AdBoard.AppServices.Contexts.FavoriteProduct.Repositories;

namespace AdBoard.AppServices.Contexts.FavoriteProduct.Services;

public class FavoriteProductService : IFavoriteProductService
{
    private readonly IFavoriteProductRepository _favoriteProductReository;

    public FavoriteProductService(IFavoriteProductRepository favoriteProductReository)
    {
        _favoriteProductReository = favoriteProductReository;
    }
}