using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Feedback.Repositories;

public interface IFeedbackRepository : IGenericRepository<FeedbackEntity, long>
{
}
