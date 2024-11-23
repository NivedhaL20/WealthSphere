using Microsoft.EntityFrameworkCore;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;

namespace WealthSphere.Repository.Implementation
{
    public class ExpenseRepository : IExpenseRepository
    {
        public readonly WealthSphereDbContext _dbContext;
        public ExpenseRepository(WealthSphereDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Expense expense)
        {
            await _dbContext.Expense.AddAsync(expense);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var expense = await _dbContext.Expense.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (expense != null)
            {
                _dbContext.Expense.Remove(expense);
                _dbContext.SaveChanges();
            }
            return true;
        }

        public async Task<List<Expense>> GetAll(Guid userId)
        {
            var expenses = await _dbContext.Expense.Where(x => x.UserId == userId).ToListAsync();
            return expenses;
        }

        public async Task<Expense> GetById(Guid id)
        {
            var expense = await _dbContext.Expense.Where(x => x.Id == id).FirstOrDefaultAsync();
            await _dbContext.SaveChangesAsync();
            return expense;
        }

        public async Task<bool> UpdateAsync(Expense expense)
        {
            var result = _dbContext.Expense.Update(expense);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<Expense>> GetExpenseByYear(int year, Guid userId)
        {
            var result = await _dbContext.Expense
                .Where(x => x.Date.Year == year && x.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<decimal> GetExpenseByCurrentMonth(int month, int year, Guid userId)
        {
            var result = await _dbContext.Expense
                .Where(x => x.Date.Year == year && x.Date.Month == month && x.UserId == userId)
                .SumAsync(x => x.Amount);
            return result;
        }
    }
}
