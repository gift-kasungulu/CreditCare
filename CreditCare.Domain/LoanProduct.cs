using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class LoanProduct
    {
        public int LoanProductId { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty; // Name of the product (e.g., Car Loan, Student Loan)
        public string Description { get; set; } = string.Empty; // Optional description of the loan product
        public decimal MaximumAmount { get; set; } // Maximum loan amount allowed for this product
        public decimal MinimumAmount { get; set; } // Minimum loan amount allowed for this product
        public decimal DefaultInterestRate { get; set; } // Default interest rate for this product optional
        public ICollection<Loan> Loans { get; set; } = new List<Loan>(); // Navigation property
    }
}
