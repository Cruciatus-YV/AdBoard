using AdBoard.AppServices.FavoriteProduct.Repositories;
using AdBoard.AppServices.Feedback.Repositories;
using AdBoard.Domain.Entities;

namespace AdBoard.DataAccess.Repositories;

public class FeedbackRepository(AdBoardDbContext _dbContext) : GenericRepository<FeedbackEntity, long>(_dbContext), IFeedbackRepository
{
}