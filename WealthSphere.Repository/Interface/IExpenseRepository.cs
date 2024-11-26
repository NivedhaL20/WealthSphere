using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Repository.Interface
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAll(Guid userId);
        Task<Expense> GetById(Guid id);
        Task<bool> AddAsync(Expense expense);
        Task<bool> UpdateAsync(Expense expense);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Expense>> GetExpenseByYear(int year, Guid userId);
        Task<decimal> GetExpenseByCurrentMonth(int month, int year, Guid userId);
        Task<decimal> GetDebtsByCurrentMonth(int month, int year, Guid userId);
    }
}
