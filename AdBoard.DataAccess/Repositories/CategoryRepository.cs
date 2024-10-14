using AdBoard.AppServices.Contexts.Category.Repositories;
using AdBoard.AppServices.Exceptions;
using AdBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdBoard.Infrastructure.Repositories;

public class CategoryRepository(AdBoardDbContext dbContext) : GenericRepository<CategoryEntity, long>(dbContext), ICategoryRepository
{
    public async Task<List<CategoryEntity>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        return await _asNoTracking.Where(x => !x.IsDeleted && x.Approved)
                                  .ToListAsync(cancellationToken);
        

    }

    public async Task<bool> DeleteCategoryAsync(long id, CancellationToken cancellationToken)
    {
        var target = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);

        if (target == null)
        {
            throw new NotFoundException("Категория не была найдена.");
        }

        target.IsDeleted = true;

        
        var children = _dbSet.Where(category => category.ParentId == id)
                             .ToList();

        foreach (var child in children)
        {
            child.ParentId = target.ParentId;
        }

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<CategoryEntity> ApproveCategoryAsync(long id, CancellationToken cancellationToken)
    {
        var target = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        if (target == null)
        {
            throw new NotFoundException("Категория не была найдена.");
        }

        target.Approved = true;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return target;
    }
}