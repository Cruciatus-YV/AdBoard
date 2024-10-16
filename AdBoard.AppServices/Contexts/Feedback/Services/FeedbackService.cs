using AdBoard.AppServices.Contexts.Feedback.Repositories;

namespace AdBoard.AppServices.Contexts.Feedback.Services;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;

    public FeedbackService(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
}
