using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int InterestRateId { get; set; } // Foreign Key
        public InterestRate? InterestRate { get; set; } //Nav prop
        public decimal ProcessingFee { get; set; }
        public int LoanStatusId { get; set; } // Foreign Key
        public LoanStatus? Status { get; set; } // Navigation Property
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Collateral> Collaterals { get; set; }

    }

}
