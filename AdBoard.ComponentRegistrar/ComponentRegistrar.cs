using AdBoard.AppServices.Cache;
using AdBoard.AppServices.Contexts.Category.Repositories;
using AdBoard.AppServices.Contexts.Category.Services;
using AdBoard.AppServices.Contexts.FavoriteProduct.Repositories;
using AdBoard.AppServices.Contexts.FavoriteProduct.Services;
using AdBoard.AppServices.Contexts.Feedback.Repositories;
using AdBoard.AppServices.Contexts.Feedback.Services;
using AdBoard.AppServices.Contexts.File.Repositories;
using AdBoard.AppServices.Contexts.File.Services;
using AdBoard.AppServices.Contexts.Order.Repositories;
using AdBoard.AppServices.Contexts.Order.Services;
using AdBoard.AppServices.Contexts.OrderItem.Repositories;
using AdBoard.AppServices.Contexts.OrderItem.Services;
using AdBoard.AppServices.Contexts.Product.Repositories;
using AdBoard.AppServices.Contexts.Product.Services;
using AdBoard.AppServices.Contexts.Product.SpecificationBuilder;
using AdBoard.AppServices.Contexts.ProductImage.Repositories;
using AdBoard.AppServices.Contexts.Store.Repositories;
using AdBoard.AppServices.Contexts.Store.Services;
using AdBoard.AppServices.Contexts.User.Services;
using AdBoard.AppServices.GenericRepository;
using AdBoard.DataAccess.Repositories;
using AdBoard.Infrastructure.Repositories;
using AdBoard.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdBoard.ComponentRegistrar;

public static class ComponentRegistrar
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<IFavoriteProductRepository, FavoriteProductRepository>();
        services.AddScoped<IFavoriteProductService, FavoriteProductService>();

        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IFeedbackService, FeedbackService>();

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();

        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderItemService, OrderItemService>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductSpecificationBuilder, ProductSpecificationBuilder>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();


        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IStoreService, StoreService>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IFileService, FileService>();

        services.AddScoped<ICacheService, CacheService>();


        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        return services;
    }
}
