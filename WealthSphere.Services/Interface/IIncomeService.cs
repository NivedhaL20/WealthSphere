using WealthSphere.Model;

namespace WealthSphere.Services.Interface
{
    public interface IIncomeService
    {
        Task<List<IncomeModel>> GetAll(Guid userId);
        Task<IncomeModel> GetById(Guid id);
        Task<bool> AddAsync(IncomeModel income);
        Task<bool> UpdateAsync(IncomeModel income);
        Task<bool> DeleteAsync(Guid id);
        Task<List<IncomeByMonth>> GetIncomeByYear(int year, Guid userId);
        Task<decimal> GetIncomeByCurrentMonth(Guid userId);
    }
}
