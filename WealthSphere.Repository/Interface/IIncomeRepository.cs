using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Repository.Interface
{
    public interface IIncomeRepository
    {
        Task<List<Income>> GetAll(Guid userId);
        Task<Income> GetById(Guid id);
        Task<bool> AddAsync(Income income);
        Task<bool> UpdateAsync(Income income);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Income>> GetIncomeByYear(int year, Guid userId);
        Task<decimal> GetIncomeByCurrentMonth(int month, int year, Guid userId);
    }
}
