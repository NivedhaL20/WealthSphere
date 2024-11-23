
namespace WealthSphere.Repository.DataAccess
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string? ExpenseType { get; set; }
        public DateTime Date { get; set; }
        public string? ModeOfPayment { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }
}
