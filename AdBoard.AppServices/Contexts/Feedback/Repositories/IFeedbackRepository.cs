using AdBoard.AppServices.GenericRepository;
using AdBoard.Domain.Entities;

namespace AdBoard.AppServices.Contexts.Feedback.Repositories;

public interface IFeedbackRepository : IGenericRepository<FeedbackEntity, long>
{
}
