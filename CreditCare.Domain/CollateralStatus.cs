using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class CollateralStatus
    {
        public int CollateralStatusId { get; set; }
        public string Name { get; set; } // E.g., Pledged, Released
    }
}
