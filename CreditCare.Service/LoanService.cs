
using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Services
{
    public class LoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetLoansByCustomerIdAsync(int customerId)
        {
            return await _context.Loans.Include(l => l.Collaterals)
                                       .Where(l => l.CustomerId == customerId).ToListAsync();
        }

        public async Task AddLoanAsync(Loan loan)
        {
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

    }

}
