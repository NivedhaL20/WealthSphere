namespace WealthSphere.Model
{
    public class InvestmentModel
    {
        public Guid Id { get; set; }
        public string? InvestmentType { get; set; }
        public string? FinancialInstitute { get; set; }
        public DateTime Date { get; set; }
        public string? ModeOfPayment { get; set; }
        public string? Purpose { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }

    public class InvestmentByMonth
    {
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
