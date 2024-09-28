using AdBoard.AppServices.GenericRepository;
using AdBoard.AppServices.Specifications;
using AdBoard.Contracts.Models.Entities.Product.Requests;
using AdBoard.Contracts.Models.Entities.Product.Responses;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Product.Repositories;

/// <summary>
/// Интерфейс для репозитория товаров. Предоставляет методы для работы с данными о товарах.
/// Наследует от <see cref="IGenericRepository{TEntity, TKey}"/> и включает методы для получения, удаления и обновления товаров.
/// </summary>
public interface IProductRepository : IGenericRepository<ProductEntity, long>
{
    /// <summary>
    /// Удаляет товар по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор товара, который нужно удалить.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>True, если товар был успешно удален; в противном случае False.</returns>
    Task<bool> DeleteProductAsync(long id,
                                  CancellationToken cancellationToken);

    /// <summary>
    /// Обновляет количество товара на складе в базе данных.
    /// </summary>
    /// <param name="buyableProducts">Список товаров для обновления количества.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Кортеж, содержащий статус обновления и список идентификаторов товаров с ошибками (если есть).</returns>
    Task<(bool, IReadOnlyCollection<long>?)> UpdateProductCountAsync(IReadOnlyCollection<ProductRequestBuyable> buyableProducts,
                                                                     CancellationToken cancellationToken);

    /// <summary>
    /// Получает список товаров, соответствующих указанному предикату, с применением сортировки и пагинации.
    /// </summary>
    /// <param name="specification">Спецификация для фильтрации товаров.</param>
    /// <param name="sortBy">Поле для сортировки (например, "Price", "Name").</param>
    /// <param name="ascending">Флаг, указывающий порядок сортировки. Если true, сортировка по возрастанию, иначе по убыванию.</param>
    /// <param name="pageNumber">Номер страницы (начиная с 1).</param>
    /// <param name="pageSize">Размер страницы (количество элементов на странице).</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Список товаров, соответствующих предикату, с примененной сортировкой и пагинацией.</returns>
    Task<List<ProductEntity>> GetProductsBySpecificationWithSortingAndPaginationAsync(ISpecification<ProductEntity> specification,
                                                                                                   string sortBy,
                                                                                                   bool ascending,
                                                                                                   int pageNumber,
                                                                                                   int pageSize,
                                                                                                   CancellationToken cancellationToken);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ProductResponse?> GetFullInfoAsync(long id, CancellationToken cancellationToken);
}
