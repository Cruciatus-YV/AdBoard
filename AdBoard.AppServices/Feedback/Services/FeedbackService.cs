using AdBoard.AppServices.Feedback.Repositories;

namespace AdBoard.AppServices.Feedback.Services;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;

    public FeedbackService(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }
}
