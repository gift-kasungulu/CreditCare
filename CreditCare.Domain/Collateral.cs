using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class Collateral
    {
        public int CollateralId { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public int CollateralStatusId {  set; get; } //Fkey
        public CollateralStatus? collateralStatus { get; set; }  //Nav prop
        public int LoanId { get; set; }
        public Loan? Loan { get; set; }
    }

}
