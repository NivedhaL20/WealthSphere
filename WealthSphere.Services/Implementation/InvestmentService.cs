using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;
using WealthSphere.Services.Interface;

namespace WealthSphere.Services.Implementation
{
    public class InvestmentService : IInvestmentService
    {
        public readonly IInvestmentRepository _investmentRepository;
        public InvestmentService(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<bool> AddAsync(InvestmentModel investmentModel)
        {
            var investment = new Investment
            {
                Id = Guid.NewGuid(),
                InvestmentType = investmentModel.InvestmentType,
                FinancialInstitute = investmentModel.FinancialInstitute,
                ModeOfPayment = investmentModel.ModeOfPayment,
                Purpose = investmentModel.Purpose,
                Date = investmentModel.Date,
                Amount = investmentModel.Amount,
                UserId = Guid.Parse(investmentModel.UserId)
            };
            var result = await _investmentRepository.AddAsync(investment);
            return result;
        }

        public async Task<bool> UpdateAsync(InvestmentModel investmentModel)
        {
            var investment = new Investment
            {
                Id = investmentModel.Id,
                InvestmentType = investmentModel.InvestmentType,
                FinancialInstitute = investmentModel.FinancialInstitute,
                ModeOfPayment = investmentModel.ModeOfPayment,
                Purpose = investmentModel.Purpose,
                Date = investmentModel.Date,
                Amount = investmentModel.Amount,
                UserId = Guid.Parse(investmentModel.UserId)
            };
            var result = await _investmentRepository.UpdateAsync(investment);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _investmentRepository.DeleteAsync(id);
            return result;
        }

        public async Task<List<InvestmentModel>> GetAll(Guid userId)
        {
            var list = new List<InvestmentModel>();
            var result = await _investmentRepository.GetAll(userId);

            foreach (var item in result)
            {
                var investment = new InvestmentModel
                {
                    Id = item.Id,
                    InvestmentType = item.InvestmentType,
                    FinancialInstitute = item.FinancialInstitute,
                    ModeOfPayment = item.ModeOfPayment,
                    Purpose = item.Purpose,
                    Date = item.Date,
                    Amount = item.Amount,
                    UserId = item.UserId.ToString()
                };
                list.Add(investment);
            }
            return list;
        }

        public async Task<InvestmentModel> GetById(Guid id)
        {
            var result = await _investmentRepository.GetById(id);
            var investment = new InvestmentModel
            {
                Id = result.Id,
                InvestmentType = result.InvestmentType,
                FinancialInstitute = result.FinancialInstitute,
                ModeOfPayment = result.ModeOfPayment,
                Purpose = result.Purpose,
                Date = result.Date,
                Amount = result.Amount,
                UserId = result.UserId.ToString()
            };
            return investment;
        }

        public async Task<List<InvestmentByMonth>> GetInvestmentByYear(int year, Guid userId)
        {
            var investments = await _investmentRepository.GetInvestmentByYear(year, userId);

            var groupedByMonth = investments.GroupBy(x => new { x.Date.Year, x.Date.Month })
                .Select(y => new InvestmentByMonth
                {
                    Month = y.Key.Month,
                    TotalAmount = y.Sum(i => i.Amount)
                })
                .OrderBy(x => x.Month).ToList();

            return groupedByMonth;
        }

        public async Task<decimal> GetInvestmentByCurrentMonth(Guid userId)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var investment = await _investmentRepository.GetInvestmentByCurrentMonth(currentMonth, currentYear, userId);
            return investment;
        }
    }
}
