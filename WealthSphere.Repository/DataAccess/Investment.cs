
namespace WealthSphere.Repository.DataAccess
{
    public class Investment
    {
        public Guid Id { get; set; }
        public string?  InvestmentType { get; set; }
        public string?  FinancialInstitute { get; set; }
        public DateTime Date { get; set; }
        public string? ModeOfPayment { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }
}
