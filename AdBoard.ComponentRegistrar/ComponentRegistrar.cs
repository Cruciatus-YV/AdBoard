using AdBoard.AppServices.Category.Repositories;
using AdBoard.AppServices.Category.Services;
using AdBoard.AppServices.FavoriteProduct.Repositories;
using AdBoard.AppServices.FavoriteProduct.Services;
using AdBoard.AppServices.Feedback.Repositories;
using AdBoard.AppServices.Feedback.Services;
using AdBoard.AppServices.GenericRepository;
using AdBoard.AppServices.Order.Repositories;
using AdBoard.AppServices.Order.Services;
using AdBoard.AppServices.OrderItem.Repositories;
using AdBoard.AppServices.OrderItem.Services;
using AdBoard.AppServices.Product.Repositories;
using AdBoard.AppServices.Product.Services;
using AdBoard.AppServices.Store.Repositories;
using AdBoard.AppServices.Store.Services;
using AdBoard.AppServices.User.Repositories;
using AdBoard.AppServices.User.Services;
using AdBoard.DataAccess.Repositories;
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

        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IStoreService, StoreService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();


        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        return services;
    }
}
