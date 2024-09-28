using AdBoard.AppServices.GenericRepository;
using AdBoard.DataAccess.Extentions;
using AdBoard.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdBoard.DataAccess.Repositories;

public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    private protected readonly AdBoardDbContext _dbContext;
    private protected readonly DbSet<TEntity> _dbSet;
    private protected readonly IQueryable<TEntity> _asNoTracking;

    public GenericRepository(AdBoardDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
        _asNoTracking = _dbSet.AsNoTracking();
    }

    public async Task<TEntity?> GetByIdAsync(TId id,
                                             CancellationToken cancellationToken)
    {
        return await _dbContext.FindAsync<TEntity>(id, cancellationToken);
    }

    public async Task<List<TEntity>> GetByPredicate(Expression<Func<TEntity, bool>> predicate,
                                                    CancellationToken cancellationToken)
    {
        return await _asNoTracking.Where(predicate)
                                  .ToListAsync(cancellationToken);
    }

    public async Task<TId> InsertAsync(TEntity entity,
                                       CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(TEntity entity,
                                        CancellationToken cancellationToken)
    {
        _dbContext.Update(entity);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> DeleteAsync(TId id,
                                        CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        if (entity != null)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }

    public async Task<List<TEntity>> GetByPredicateAndPaginationAsync(Expression<Func<TEntity, bool>> predicate,
                                                                      int pageNumber,
                                                                      int pageSize,
                                                                      CancellationToken cancellationToken)
    {
        return await _asNoTracking.Where(predicate)
                                  .PaginationListAsync(pageNumber, pageSize, cancellationToken);
    }

    public async Task<bool> ExistsAsync(TId id,
                                        CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(e => Object.Equals(e.Id, id), cancellationToken);
    }
}