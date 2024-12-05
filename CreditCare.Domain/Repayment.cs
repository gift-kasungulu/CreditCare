using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class Repayment
    {
        public int RepaymentId { get; set; }
        public string PaymentReference { get; set; } = string.Empty;
        public string PaymentMethod{ get; set; } = string.Empty;

        public int LoanId { get; set; } // Foreign Key
        public Loan? Loan { get; set; } // Navigation property
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

}
