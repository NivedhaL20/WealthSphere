using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Repository.Interface
{
    public interface IGoalSettingRepository
    {
        Task<GoalSetting> GetById(Guid id);
        Task<bool> AddAsync(GoalSetting goalSetting);
        Task<bool> UpdateAsync(GoalSetting goalSetting);
    }
}
