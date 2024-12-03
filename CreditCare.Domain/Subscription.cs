using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string PlanName { get; set; }
        public decimal MonthlyFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }


}
