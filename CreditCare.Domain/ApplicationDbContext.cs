using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreditCare.Domain
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Collateral> Collaterals { get; set; }
        public virtual DbSet<CollateralStatus> CollateralStatus { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanStatus> LoanStatuses { get; set; }
        public virtual DbSet<InterestRate> IRates { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        
        



    }
}
