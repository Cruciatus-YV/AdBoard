using AdBoard.AppServices.Contexts.Product.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace AdBoard.ApiTests
{
    public class TestWebApplication : WebApplicationFactory<WebAPI.Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var redisDescriptor = services.First(x => x.ServiceType == typeof(IDistributedCache));
                services.Remove(redisDescriptor);
                services.AddSingleton<IDistributedCache, MemoryDistributedCache>();

                var repositoryDescriptor = services.First(x => x.ServiceType == typeof(IProductRepository));
                services.Remove(repositoryDescriptor);
                services.AddScoped<IProductRepository, ProductRepositoryStub>();
            });
        }
    }
}
