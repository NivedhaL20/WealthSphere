using WealthSphere.Model;

namespace WealthSphere.Services.Interface
{
    public interface IFeedbackService
    {
        Task<bool> AddAsync(FeedbackModel feedback);
    }
}
