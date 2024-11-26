using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;

namespace WealthSphere.Repository.Implementation
{
    public class GoalSettingRepository : IGoalSettingRepository
    {
        public readonly WealthSphereDbContext _dbContext;
        public GoalSettingRepository(WealthSphereDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(GoalSetting goalSetting)
        {
            await _dbContext.GoalSetting.AddAsync(goalSetting);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<GoalSetting> GetById(Guid id)
        {
            var goalSetting = await _dbContext.GoalSetting.Where(x => x.Id == id).FirstOrDefaultAsync();
            await _dbContext.SaveChangesAsync();
            return goalSetting;
        }

        public async Task<bool> UpdateAsync(GoalSetting goalSetting)
        {
            var result = _dbContext.GoalSetting.Update(goalSetting);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
