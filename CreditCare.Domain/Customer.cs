using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NrcNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public ICollection<Loan> Loans { get; set; } 
    }

}
