namespace WealthSphere.Model
{
    public class InvestmentModel
    {
        public Guid Id { get; set; }
    }

    public class InvestmentByMonth
    {
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
