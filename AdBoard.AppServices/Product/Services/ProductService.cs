using AdBoard.AppServices.Product.Repositories;

namespace AdBoard.AppServices.Product.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
}