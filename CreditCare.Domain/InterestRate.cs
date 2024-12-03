using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class InterestRate
    {
        public int InterestRateId { get; set; } 
        public decimal Rate { get; set; } // Interest rate value (e.g., 5.5 for 5.5%)
        public string Description { get; set; } // Description of the rate (e.g., "Monthly Rate")
        public string Term { get; set; } // Duration term (e.g., "1 Week", "2 Weeks", "1 Month")
      
    }
}
