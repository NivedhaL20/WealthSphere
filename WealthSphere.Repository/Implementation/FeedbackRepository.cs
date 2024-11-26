using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;

namespace WealthSphere.Repository.Implementation
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public readonly WealthSphereDbContext _dbContext;
        public FeedbackRepository(WealthSphereDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Feedback feedback)
        {
            await _dbContext.Feedback.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
