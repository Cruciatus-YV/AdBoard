using AdBoard.AppServices.Contexts.Feedback.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.Infrastructure.Repositories;

public class FeedbackRepository(AdBoardDbContext _dbContext) : GenericRepository<FeedbackEntity, long>(_dbContext), IFeedbackRepository
{
}