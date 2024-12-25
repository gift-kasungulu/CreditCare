using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreditCare.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
        public virtual DbSet<LoanProduct> LoanProducts { get; set; }
        public virtual DbSet<Repayment> Repayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.Loan)
                .WithMany(l => l.Collaterals) // Reference the navigation property in Loan
                .HasForeignKey(c => c.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.collateralStatus)
                .WithMany()
                .HasForeignKey(c => c.CollateralStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
