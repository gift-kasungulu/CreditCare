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
        public string LoanNumber { get; set; } = string.Empty;// new property for storing the loan number, will be auto generated with 4 digits
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int InterestRateId { get; set; } // Foreign Key
        public InterestRate? InterestRate { get; set; } //Nav prop
        public decimal ProcessingFee { get; set; }
        // New property for repayment amount
        public decimal RepaymentAmount { get; set; }
        public int LoanStatusId { get; set; } // Foreign Key
        public LoanStatus? Status { get; set; } // Navigation Property
        public int CustomerId { get; set; }   //Fkey 
        public Customer? Customer { get; set; } //Nav
        public ICollection<Collateral> Collaterals { get; set; }

        public ICollection<Repayment> Repayments { get; set; } = new List<Repayment>();

        //new props
        public enum LoanPeriodType
        {
            Weekly,      // 1 week
            BiWeekly,    // 2 weeks
            ThreeWeeks,  // 3 weeks
            FourWeeks,   // 4 weeks
            Monthly,     // 1 month
            Quarterly,   // 3 months
            SemiAnnual,  // 6 months
            Annual       // 12 months
        }

        public LoanPeriodType PeriodType { get; set; }
        public int RepaymentCycles { get; set; }

        public int LoanProductId { get; set; } // Foreign Key
        public LoanProduct LoanProduct { get; set; } // Navigation Property



    }

}
