using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Implementation;
using WealthSphere.Repository.Interface;
using WealthSphere.Services.Interface;

namespace WealthSphere.Services.Implementation
{
    public class GoalSettingService : IGoalSettingService
    {
        public readonly IGoalSettingRepository _goalSettingRepository;
        public GoalSettingService(IGoalSettingRepository goalSettingRepository)
        {
            _goalSettingRepository = goalSettingRepository;
        }
        public async Task<bool> AddAsync(GoalSettingModel goalSettingModel)
        {
            var expense = new GoalSetting
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(goalSettingModel.UserId),
            };
            var result = await _goalSettingRepository.AddAsync(expense);
            return result;
        }

        public async Task<GoalSettingModel> GetById(Guid id)
        {
            var result = await _goalSettingRepository.GetById(id);
            var expense = new GoalSettingModel
            {
                Id = result.Id,                
                UserId = result.UserId.ToString(),
            };
            return expense;
        }

        public async Task<bool> UpdateAsync(GoalSettingModel goalSettingModel)
        {
            var expense = new GoalSetting
            {
                Id = goalSettingModel.Id,
                UserId = Guid.Parse(goalSettingModel.UserId)
            };
            var result = await _goalSettingRepository.UpdateAsync(expense);
            return result;
        }
    }
}
