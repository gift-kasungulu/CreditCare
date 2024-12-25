
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsSubscribed { get; set; } = false;
        public DateTime? SubscriptionEndDate { get; set; }
        public DateTime TrialEndDate { get; set; }
    }
}
