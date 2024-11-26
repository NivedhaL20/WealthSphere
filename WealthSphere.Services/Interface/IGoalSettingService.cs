using WealthSphere.Model;

namespace WealthSphere.Services.Interface
{
    public interface IGoalSettingService
    {       
        Task<GoalSettingModel> GetById(Guid id);
        Task<bool> AddAsync(GoalSettingModel expense);
        Task<bool> UpdateAsync(GoalSettingModel expense);       
    }
}
