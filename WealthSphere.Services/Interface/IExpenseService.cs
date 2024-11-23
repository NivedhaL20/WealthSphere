using System;
using WealthSphere.Model;

namespace WealthSphere.Services.Interface
{
    public interface IExpenseService
    {
        Task<List<ExpenseModel>> GetAll(Guid userId);
        Task<ExpenseModel> GetById(Guid id);
        Task<bool> AddAsync(ExpenseModel expense);
        Task<bool> UpdateAsync(ExpenseModel expense);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ExpenseByMonth>> GetExpenseByYear(int year, Guid userId);
        Task<decimal> GetExpenseByCurrentMonth(Guid userId);
    }
}
