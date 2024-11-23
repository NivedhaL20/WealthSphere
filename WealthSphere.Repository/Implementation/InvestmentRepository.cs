using Microsoft.EntityFrameworkCore;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;

namespace WealthSphere.Repository.Implementation
{
    public class InvestmentRepository : IInvestmentRepository
    {
        public readonly WealthSphereDbContext _dbContext;
        public InvestmentRepository(WealthSphereDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Investment investment)
        {
            await _dbContext.Investment.AddAsync(investment);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var investment = await _dbContext.Investment.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (investment != null)
            {
                _dbContext.Investment.Remove(investment);
                _dbContext.SaveChanges();
            }
            return true;
        }

        public async Task<List<Investment>> GetAll(Guid userId)
        {
            var investments = await _dbContext.Investment.Where(x => x.UserId == userId).ToListAsync();
            return investments;
        }

        public async Task<Investment> GetById(Guid id)
        {
            var investment = await _dbContext.Investment.Where(x => x.Id == id).FirstOrDefaultAsync();
            await _dbContext.SaveChangesAsync();
            return investment;
        }

        public async Task<bool> UpdateAsync(Investment investment)
        {
            var result = _dbContext.Investment.Update(investment);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<Investment>> GetInvestmentByYear(int year, Guid userId)
        {
            var result = await _dbContext.Investment
                .Where(x => x.Date.Year == year && x.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<decimal> GetInvestmentByCurrentMonth(int month, int year, Guid userId)
        {
            var result = await _dbContext.Investment
                .Where(x => x.Date.Year == year && x.Date.Month == month && x.UserId == userId)
                .SumAsync(x => x.Amount);
            return result;
        }
    }
}
