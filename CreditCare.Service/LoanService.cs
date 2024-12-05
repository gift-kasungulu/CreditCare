
using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreditCare.Domain.Loan;

namespace CreditCare.Services
{
    public class LoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoanProduct>> GetAllLoanProductsAsync()
        {
            return await _context.LoanProducts.ToListAsync();
        }

        public async Task UpdateLoan(Loan loan)  //recently added 
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Loan>> GetAllLoansWithRepaymentAsync()
        {
            var loans = await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.InterestRate)
                .Include(l => l.Status)
                .ToListAsync();

            foreach (var loan in loans)
            {
                loan.RepaymentAmount = CalculateRepaymentAmount(loan); // Assuming `RepaymentAmount` is a property in Loan
            }

            return loans;
        }

        public decimal CalculateRepaidAmount(Loan loan)
        {
            return loan.Repayments?.Sum(r => r.Amount) ?? 0m;
        }

        public async Task<List<Loan>> GetSettledLoansAsync()
        {
            return await _context.Loans
                .Include(l => l.Repayments)
                .Include(l => l.Status)
                .Where(l => l.Status.Name == "Settled")
                .ToListAsync();
        }

        public async Task AddRepaymentAsync(int loanId, decimal repaymentAmount, string paymentMethod, string paymentReference)
        {
            // Fetch the loan including repayments
            var loan = await _context.Loans
                                      .Include(l => l.Repayments)
                                      .FirstOrDefaultAsync(l => l.LoanId == loanId);
            if (loan == null)
            {
                throw new Exception("Loan not found.");
            }

            // Create and add a new repayment record
            var repayment = new Repayment
            {
                LoanId = loan.LoanId,
                Amount = repaymentAmount,
                PaymentMethod = paymentMethod,
                PaymentReference = paymentReference,
                Date = DateTime.Now
            };
            _context.Repayments.Add(repayment);

            // Check if the loan is fully repaid
            decimal totalRepaid = loan.Repayments.Sum(r => r.Amount) + repaymentAmount; // Include the new repayment
            decimal totalRepayment = CalculateRepaymentAmount(loan);

            if (totalRepaid >= totalRepayment)
            {
                // Fetch "Paid" status from the LoanStatuses table
                var paidStatus = await _context.LoanStatuses
                                               .FirstOrDefaultAsync(s => s.Name == "Paid");
                if (paidStatus != null)
                {
                    loan.LoanStatusId = paidStatus.LoanStatusId; // Update loan status to "Paid"
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        public decimal CalculateRepaymentAmount(Loan loan)
        {
            if (loan.InterestRate == null)
                throw new InvalidOperationException("Interest rate is required to calculate repayment.");

            // Calculate total interest
            decimal interestAmount = loan.PrincipalAmount * (loan.InterestRate.Rate / 100m);

            // Total repayment without processing fee
            return loan.PrincipalAmount + interestAmount;
        }

        public async Task UpdateLoanStatusesAsync()
        {
            var now = DateTime.Now;

            // Find loans that are past due and not already settled or defaulted
            var pastDueLoans = await _context.Loans
                .Include(l => l.Status)
                .Where(l => l.DueDate < now &&
                            l.Status.Name != "Settled" &&
                            l.Status.Name != "Defaulted")
                .ToListAsync();

            var defaultedStatus = await _context.LoanStatuses
                .FirstOrDefaultAsync(ls => ls.Name == "Defaulted");

            if (defaultedStatus == null)
            {
                throw new InvalidOperationException("Defaulted status not found in database.");
            }

            foreach (var loan in pastDueLoans)
            {
                loan.Status = defaultedStatus;
            }

            await _context.SaveChangesAsync();
        }

        public async Task MarkLoanAsPaidAsync(int loanId)
        {
            var loan = await _context.Loans
                .Include(l => l.Status)
                .FirstOrDefaultAsync(l => l.LoanId == loanId);

            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with ID {loanId} not found.");
            }

            var settledStatus = await _context.LoanStatuses
                .FirstOrDefaultAsync(ls => ls.Name == "Settled");

            if (settledStatus == null)
            {
                throw new InvalidOperationException("Settled status not found in database.");
            }

            loan.Status = settledStatus;
            await _context.SaveChangesAsync();
        }

        private DateTime CalculateDueDate(DateTime startDate, LoanPeriodType periodType, int cycles)
        {
            return periodType switch
            {
                LoanPeriodType.Weekly => startDate.AddDays(7 * cycles),
                LoanPeriodType.BiWeekly => startDate.AddDays(14 * cycles),
                LoanPeriodType.ThreeWeeks => startDate.AddDays(21 * cycles),
                LoanPeriodType.FourWeeks => startDate.AddDays(28 * cycles),
                LoanPeriodType.Monthly => startDate.AddMonths(1 * cycles),
                LoanPeriodType.Quarterly => startDate.AddMonths(3 * cycles),
                LoanPeriodType.SemiAnnual => startDate.AddMonths(6 * cycles),
                LoanPeriodType.Annual => startDate.AddYears(1 * cycles),
                _ => throw new ArgumentException("Invalid period type")
            };
        }

        public async Task<List<Loan>> GetAllLoansAsync()
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.InterestRate)
                .Include(l => l.Status)
                .ToListAsync();
        }

        public async Task<List<LoanStatus>> GetAllLoanStatusesAsync()
        {
            return await _context.LoanStatuses.ToListAsync();
        }

        public async Task<List<Loan>> GetLoansByCustomerIdAsync(int customerId)
        {
            return await _context.Loans
                .Include(l => l.Collaterals)
                .Include(l => l.Customer)
                .Include(l => l.InterestRate)
                .Include(l => l.Status)
                .Where(l => l.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<string> GetLastLoanNumberAsync()
        {
            return await _context.Loans
                .OrderByDescending(l => l.LoanId)
                .Select(l => l.LoanNumber)
                .FirstOrDefaultAsync();
        }

        public async Task AddLoanAsync(Loan loan)
        {
            // Ensure related entities are properly set
            if (loan.Customer != null)
            {
                loan.CustomerId = loan.Customer.CustomerId;
                loan.Customer = null; // Detach to prevent EF from trying to add the whole customer
            }

            if (loan.InterestRate != null)
            {
                loan.InterestRateId = loan.InterestRate.InterestRateId;
                loan.InterestRate = null;
            }

            if (loan.Status != null)
            {
                loan.LoanStatusId = loan.Status.LoanStatusId;
                loan.Status = null;
            }

            if (loan.StartDate.HasValue) // handling the due date here 
            {
                loan.DueDate = CalculateDueDate(loan.StartDate.Value, loan.PeriodType, loan.RepaymentCycles);
            }

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoanStatusAsync(int loanId, string status)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan != null)
            {
                // Find the LoanStatus entity by its name or another identifier
                var loanStatus = await _context.LoanStatuses.FirstOrDefaultAsync(ls => ls.Name == status);
                if (loanStatus != null)
                {
                    loan.Status = loanStatus; // Assign the LoanStatus object
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException($"LoanStatus with name '{status}' does not exist.");
                }
            }
            else
            {
                throw new KeyNotFoundException($"Loan with ID {loanId} was not found.");
            }
        }

        //method to try adding the repayment
        public async Task AddRepaymentAsync(Repayment repayment)
        {
            try
            {
                // Assuming _dbContext is your DbContext for the database
                _context.Repayments.Add(repayment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding repayment: " + ex.Message);
            }
        }

        public async Task<List<Repayment>> GetRepaymentsByLoanIdAsync(int loanId)
        {
            try
            {
                // Assuming `Repayments` is your DbSet for repayment records
                return await _context.Repayments
                    .Where(r => r.LoanId == loanId)
                    .OrderBy(r => r.Date)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving repayments: " + ex.Message);
            }
        }
        public async Task<List<Loan>> GetAllLoansAsync(bool includeRepayments = false)
        {
            var query = _context.Loans.AsQueryable();

            if (includeRepayments)
            {
                query = query.Include(l => l.Repayments);
            }

            return await query.ToListAsync();
        }

    }

}
