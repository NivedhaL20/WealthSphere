using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;
using WealthSphere.Services.Interface;

namespace WealthSphere.Services.Implementation
{
    public class IncomeService : IIncomeService
    {
        public readonly IIncomeRepository _incomeRepository;
        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<bool> AddAsync(IncomeModel incomeModel)
        {
            var income = new Income
            {
                Id = Guid.NewGuid(),
                IncomeSource= incomeModel.IncomeSource,
                MonthlyIncome = incomeModel.MonthlyIncome,
                Date=incomeModel.Date,
                OtherSource=incomeModel.OtherSource,
                TotalCTC=incomeModel.TotalCTC
                UserId = Guid.Parse(incomeModel.UserId)
            };
            var result = await _incomeRepository.AddAsync(income);
            return result;
        }

        public async Task<bool> UpdateAsync(IncomeModel incomeModel)
        {
            var income = new Income
            {
                Id = incomeModel.Id,
                IncomeSource = incomeModel.IncomeSource,
                MonthlyIncome = incomeModel.MonthlyIncome,
                Date = incomeModel.Date,
                OtherSource = incomeModel.OtherSource,
                TotalCTC = incomeModel.TotalCTC,
                UserId = Guid.Parse(incomeModel.UserId)
            };
            var result = await _incomeRepository.UpdateAsync(income);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _incomeRepository.DeleteAsync(id);
            return result;
        }

        public async Task<List<IncomeModel>> GetAll(Guid userId)
        {
            var list = new List<IncomeModel>();
            var result = await _incomeRepository.GetAll(userId);

            foreach(var item in result)
            {
                var income = new IncomeModel
                {
                    Id = item.Id,
                    IncomeSource = item.IncomeSource,
                    MonthlyIncome = item.MonthlyIncome,
                    Date = item.Date,
                    OtherSource = item.OtherSource,
                    TotalCTC = item.TotalCTC,
                    UserId = item.UserId.ToString()
                };
                list.Add(income);
            }            
            return list;
        }

        public async Task<IncomeModel> GetById(Guid id)
        {
            var result = await _incomeRepository.GetById(id);
            var income = new IncomeModel
            {
                Id = result.Id,
                IncomeSource = result.IncomeSource,
                MonthlyIncome = result.MonthlyIncome,
                Date = result.Date,
                OtherSource = result.OtherSource,
                TotalCTC = result.TotalCTC,
                UserId = result.UserId.ToString()
            };
            return income;            
        }

        public async Task<List<IncomeByMonth>> GetIncomeByYear(int year, Guid userId)
        {
            var incomes = await _incomeRepository.GetIncomeByYear(year, userId);

            var groupedByMonth = incomes.GroupBy(x => new { x.Date.Year, x.Date.Month })
                .Select(y => new IncomeByMonth
                {
                    Month = y.Key.Month,
                    TotalAmount = y.Sum(i => i.MonthlyIncome)
                })
                .OrderBy(x => x.Month).ToList();            
            
            return groupedByMonth;
        }

        public async Task<decimal> GetIncomeByCurrentMonth(Guid userId)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var income = await _incomeRepository.GetIncomeByCurrentMonth(currentMonth, currentYear, userId);
            return income;
        }
    }
}
