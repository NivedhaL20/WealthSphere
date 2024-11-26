
namespace WealthSphere.Model
{
    public class ExpenseModel
    {
        public Guid Id { get; set; }
        public string ?ExpenseType { get; set; }
        public DateTime Date { get; set; }
        public string ?ModeOfPayment { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }

    public class ExpenseByMonth
    {
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class ExpenseByCategory
    {
        public string Category { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
