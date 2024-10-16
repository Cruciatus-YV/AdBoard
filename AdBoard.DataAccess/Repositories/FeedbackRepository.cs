using AdBoard.AppServices.Contexts.Feedback.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.Infrastructure.Repositories;

/// <summary>
/// Репозиторий, работающий с отзывами.
/// </summary>
public class FeedbackRepository(AdBoardDbContext _dbContext) : GenericRepository<FeedbackEntity, long>(_dbContext), IFeedbackRepository
{
}