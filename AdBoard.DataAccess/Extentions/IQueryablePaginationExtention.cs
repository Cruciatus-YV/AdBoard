using Microsoft.EntityFrameworkCore;

namespace AdBoard.DataAccess.Extentions;

/// <summary>
/// Расширения для пагинации запросов IQueryable.
/// </summary>
public static class IQueryablePaginationExtention
{
    /// <summary>
    /// Применяет пагинацию к запросу IQueryable и возвращает отфильтрованные результаты.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="queryable">Запрос IQueryable.</param>
    /// <param name="pageNumber">Номер страницы (начиная с 1).</param>
    /// <param name="pageSize">Размер страницы (количество элементов на странице).</param>
    /// <returns>Отфильтрованный запрос IQueryable с примененной пагинацией.</returns>
    public static IQueryable<TEntity> Pagination<TEntity>(this IQueryable<TEntity> queryable,
                                                          int pageNumber,
                                                          int pageSize)
        => queryable.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

    /// <summary>
    /// Асинхронно выполняет пагинацию и возвращает отфильтрованный список результатов.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="queryable">Запрос IQueryable.</param>
    /// <param name="pageNumber">Номер страницы (начиная с 1).</param>
    /// <param name="pageSize">Размер страницы (количество элементов на странице).</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции.</param>
    /// <returns>Список отфильтрованных результатов.</returns>
    public async static Task<List<TEntity>> PaginationListAsync<TEntity>(this IQueryable<TEntity> queryable,
                                                                         int pageNumber,
                                                                         int pageSize,
                                                                         CancellationToken cancellationToken)
        => await queryable.Skip((pageNumber - 1) * pageSize)
                          .Take(pageSize)
                          .ToListAsync(cancellationToken);

    /// <summary>
    /// Асинхронно выполняет пагинацию и возвращает отфильтрованный массив результатов.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <param name="queryable">Запрос IQueryable.</param>
    /// <param name="pageNumber">Номер страницы (начиная с 1).</param>
    /// <param name="pageSize">Размер страницы (количество элементов на странице).</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции.</param>
    /// <returns>Массив отфильтрованных результатов.</returns>
    public async static Task<TEntity[]> PaginationArrayAsync<TEntity>(this IQueryable<TEntity> queryable,
                                                                      int pageNumber,
                                                                      int pageSize,
                                                                      CancellationToken cancellationToken)
        => await queryable.Skip((pageNumber - 1) * pageSize)
                          .Take(pageSize)
                          .ToArrayAsync(cancellationToken);
}