using Microsoft.EntityFrameworkCore;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;

namespace WealthSphere.Repository.Implementation
{
    public class IncomeRepository : IIncomeRepository
    {
        public readonly WealthSphereDbContext _dbContext;
        public IncomeRepository(WealthSphereDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Income income)
        {
            await _dbContext.Income.AddAsync(income);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var income = await _dbContext.Income.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(income != null)
            {
                _dbContext.Income.Remove(income);
                _dbContext.SaveChanges();
            }

            return true;
        }

        public async Task<List<Income>> GetAll(Guid userId)
        {
            var incomes = await _dbContext.Income.Where(x => x.UserId == userId).ToListAsync();
            return incomes;
        }

        public async Task<Income> GetById(Guid id)
        {
            var income = await _dbContext.Income.Where(x => x.Id == id).FirstOrDefaultAsync();
            await _dbContext.SaveChangesAsync();
            return income;
        }        

        public async Task<bool> UpdateAsync(Income income)
        {
            var result = _dbContext.Income.Update(income);
            await _dbContext.SaveChangesAsync();
            return true;
            
        }

        public async Task<List<Income>> GetIncomeByYear(int year, Guid userId)
        {
            var result = await _dbContext.Income.Where(x => x.Date.Year == year && x.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<decimal> GetIncomeByCurrentMonth(int month, int year, Guid userId)
        {
            var result = await _dbContext.Income
                .Where(x => x.Date.Year == year && x.Date.Month == month && x.UserId == userId)
                .SumAsync(x => x.MonthlyIncome);
            return result;
        }
    }
}
