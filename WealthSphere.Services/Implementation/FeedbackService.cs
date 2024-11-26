using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Implementation;
using WealthSphere.Repository.Interface;
using WealthSphere.Services.Interface;

namespace WealthSphere.Services.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        public readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;

        }
        public async Task<bool> AddAsync(FeedbackModel feedbackModel)
        {
            var feedback = new Feedback
            {
                Id = Guid.NewGuid(),
                VisuallyAppealing = feedbackModel.VisuallyAppealing,
                AnyChangesRequired = feedbackModel.AnyChangesRequired,
                EasyToAccess = feedbackModel.EasyToAccess,
                MostLikedFeature = feedbackModel.MostLikedFeature,
                Rating = feedbackModel.Rating,
                UserId = Guid.Parse(feedbackModel.UserId)
            };
            var result = await _feedbackRepository.AddAsync(feedback);
            return result;
        }
    }
}
