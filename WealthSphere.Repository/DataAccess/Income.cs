using System.ComponentModel.DataAnnotations;

namespace WealthSphere.Repository.DataAccess
{
    public class Income
    {
        [Key]
        public Guid Id { get; set; }
        public string? IncomeSource { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCTC { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string? OtherSource { get; set; }
        public Guid UserId { get; set; }
    }    
}
