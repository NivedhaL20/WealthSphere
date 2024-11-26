using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;
using WealthSphere.Services.Interface;

namespace WealthSphere.Services.Implementation
{
    public class ExpenseService : IExpenseService
    {
        public readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<bool> AddAsync(ExpenseModel expenseModel)
        {
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                ExpenseType = expenseModel.ExpenseType,
                ModeOfPayment = expenseModel.ModeOfPayment,
                Date = expenseModel.Date,
                Amount = expenseModel.Amount,
                UserId = expenseModel.UserId,
            };
            var result = await _expenseRepository.AddAsync(expense);
            return result;
        }

        public async Task<bool> UpdateAsync(ExpenseModel expenseModel)
        {
            var expense = new Expense
            {
                Id = expenseModel.Id,
                ExpenseType = expenseModel.ExpenseType,
                ModeOfPayment = expenseModel.ModeOfPayment,
                Date = expenseModel.Date,
                Amount = expenseModel.Amount,
                UserId = expenseModel.UserId
            };
            var result = await _expenseRepository.UpdateAsync(expense);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _expenseRepository.DeleteAsync(id);
            return result;
        }

        public async Task<List<ExpenseModel>> GetAll(Guid userId)
        {
            var list = new List<ExpenseModel>();
            var result = await _expenseRepository.GetAll(userId);

            foreach (var item in result)
            {
                var expense = new ExpenseModel
                {
                    Id = item.Id,
                    ExpenseType = item.ExpenseType,
                    ModeOfPayment = item.ModeOfPayment,
                    Date = item.Date,
                    Amount = item.Amount,
                    UserId = item.UserId
                };
                list.Add(expense);
            }
            return list;
        }

        public async Task<ExpenseModel> GetById(Guid id)
        {
            var result = await _expenseRepository.GetById(id);
            var expense = new ExpenseModel
            {
                Id = result.Id,
                ExpenseType = result.ExpenseType,
                ModeOfPayment = result.ModeOfPayment,
                Date = result.Date,
                Amount = result.Amount,
                UserId= result.UserId
            };
            return expense;
        }

        public async Task<List<ExpenseByMonth>> GetExpenseByYear(int year, Guid userId)
        {
            var expenses = await _expenseRepository.GetExpenseByYear(year, userId);

            var groupedByMonth = expenses.GroupBy(x => new { x.Date.Year, x.Date.Month })
                .Select(y => new ExpenseByMonth
                {
                    Month = y.Key.Month,
                    TotalAmount = y.Sum(i => i.Amount)
                })
                .OrderBy(x => x.Month).ToList();

            return groupedByMonth;
        }

        public async Task<decimal> GetExpenseByCurrentMonth(Guid userId)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var expense = await _expenseRepository.GetExpenseByCurrentMonth(currentMonth, currentYear, userId);
            return expense;
        }

        public async Task<decimal> GetDebtsByCurrentMonth(Guid userId)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var expense = await _expenseRepository.GetDebtsByCurrentMonth(currentMonth, currentYear, userId);
            return expense;
        }
    }
}
