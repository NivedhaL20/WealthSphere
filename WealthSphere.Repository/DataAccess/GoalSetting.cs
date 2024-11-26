using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthSphere.Repository.DataAccess
{
    public class GoalSetting
    {
        public Guid Id { get; set; }
        public decimal HowMuchIncomeForMonth { get; set; }
        public decimal HowMuchSpendForMonth { get; set; }
        public decimal HowMuchSaveForMonth { get; set; }
        public decimal HowMuchDebtsForMonth { get; set; }
        public decimal HowMuchEmergencyFundForMonth { get; set; }
        public Guid UserId { get; set; }
    }
}
