using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Repository.Interface
{
    public interface IInvestmentRepository
    {
        Task<List<Investment>> GetAll(Guid userId);
        Task<Investment> GetById(Guid id);
        Task<bool> AddAsync(Investment investment);
        Task<bool> UpdateAsync(Investment investment);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Investment>> GetInvestmentByYear(int year, Guid userId);
        Task<decimal> GetInvestmentByCurrentMonth(int month, int year, Guid userId);
    }
}
