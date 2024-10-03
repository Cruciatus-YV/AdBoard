using AdBoard.AppServices.Contexts.Category.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdBoard.Infrastructure.Repositories;

public class CategoryRepository(AdBoardDbContext dbContext) : GenericRepository<CategoryEntity, long>(dbContext), ICategoryRepository
{
    public async Task<List<CategoryEntity>> GetBreadcrumbsByIdAsync(long categoryId,
                                                                CancellationToken cancellationToken)
    {
        var sql = @"
        WITH RECURSIVE category_tree AS (
            SELECT ""Id"", ""Name"", ""ParentId"", ""IsDeleted"", ""Approved"", 0 AS ""level""
            FROM ""Categories""
            WHERE ""Id"" = {0}

            UNION ALL

            SELECT c.""Id"", c.""Name"", c.""ParentId"", c.""IsDeleted"", c.""Approved"", ct.""level"" - 1
            FROM ""Categories"" c
            INNER JOIN category_tree ct ON c.""Id"" = ct.""ParentId""
        )
        SELECT ""Id"", ""Name"", ""ParentId"", ""IsDeleted"", ""Approved""
        FROM category_tree
        ORDER BY ""level"", ""Id"";
    ";

        return await _dbSet.FromSqlRaw(sql, categoryId)
                           .ToListAsync(cancellationToken);
    }


    public async Task<List<CategoryEntity>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        return await _asNoTracking.Where(x => !x.IsDeleted && x.Approved)
                                  .ToListAsync(cancellationToken);

    }

    public async Task<bool> DeleteCategoryAsync(long id,
                                                CancellationToken cancellationToken)
    {
        var target = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);

        if (target == null)
        {
            throw new NotFoundException("Категория не была найдена.");
        }

        target.IsDeleted = true;

        // Обновление дочерних категорий
        var children = _dbSet.Where(category => category.ParentId == id)
                             .ToList();

        foreach (var child in children)
        {
            child.ParentId = target.ParentId;
        }

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> ApproveCategoryAsync(long id, CancellationToken cancellationToken)
    {
        var target = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        if (target == null)
        {
            throw new NotFoundException("Категория не была найдена.");
        }

        target.Approved = true;

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}