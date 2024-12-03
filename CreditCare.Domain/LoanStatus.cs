using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class LoanStatus
    {
        public int LoanStatusId { get; set; } 
        public string Name { get; set; } // e.g., "Pending", "Active", "Settled", "Defaulted" these will be dynamic will be adding them pre
    }
}
