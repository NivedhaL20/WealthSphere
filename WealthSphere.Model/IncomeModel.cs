using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthSphere.Model
{
    public class IncomeModel
    {
        public Guid Id { get; set; }
        public string ?IncomeSource { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCTC { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string ?OtherSource { get; set; }
        public Guid UserId { get; set; }
    }

    public class IncomeByMonth
    {
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
