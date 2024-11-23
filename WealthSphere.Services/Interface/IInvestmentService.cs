
using WealthSphere.Model;

namespace WealthSphere.Services.Interface
{
    public interface IInvestmentService
    {
        Task<List<InvestmentModel>> GetAll(Guid userId);
        Task<InvestmentModel> GetById(Guid id);
        Task<bool> AddAsync(InvestmentModel investment);
        Task<bool> UpdateAsync(InvestmentModel investment);
        Task<bool> DeleteAsync(Guid id);
        Task<List<InvestmentByMonth>> GetInvestmentByYear(int year, Guid userId);
        Task<decimal> GetInvestmentByCurrentMonth(Guid userId);
    }
}
