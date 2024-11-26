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
                HowMuchDebtsForMonth = goalSettingModel.HowMuchDebtsForMonth,
                HowMuchEmergencyFundForMonth = goalSettingModel.HowMuchEmergencyFundForMonth,
                HowMuchIncomeForMonth = goalSettingModel.HowMuchIncomeForMonth,
                HowMuchSaveForMonth = goalSettingModel.HowMuchSaveForMonth,
                HowMuchSpendForMonth = goalSettingModel.HowMuchSpendForMonth,
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
                HowMuchDebtsForMonth = result.HowMuchDebtsForMonth,
                HowMuchEmergencyFundForMonth = result.HowMuchEmergencyFundForMonth,
                HowMuchIncomeForMonth = result.HowMuchIncomeForMonth,
                HowMuchSaveForMonth = result.HowMuchSaveForMonth,
                HowMuchSpendForMonth = result.HowMuchSpendForMonth,
                UserId = result.UserId.ToString(),
            };
            return expense;
        }

        public async Task<bool> UpdateAsync(GoalSettingModel goalSettingModel)
        {
            var expense = new GoalSetting
            {
                Id = goalSettingModel.Id,
                HowMuchDebtsForMonth = goalSettingModel.HowMuchDebtsForMonth,
                HowMuchEmergencyFundForMonth = goalSettingModel.HowMuchEmergencyFundForMonth,
                HowMuchIncomeForMonth = goalSettingModel.HowMuchIncomeForMonth,
                HowMuchSaveForMonth = goalSettingModel.HowMuchSaveForMonth,
                HowMuchSpendForMonth = goalSettingModel.HowMuchSpendForMonth,
                UserId = Guid.Parse(goalSettingModel.UserId)
            };
            var result = await _goalSettingRepository.UpdateAsync(expense);
            return result;
        }
    }
}
