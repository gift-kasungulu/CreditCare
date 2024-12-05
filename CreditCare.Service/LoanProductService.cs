using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public class LoanProductService : ILoanProductService
    {
        private readonly ApplicationDbContext _context;

        public LoanProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanProduct>> GetAllLoanProductsAsync()
        {
            return await _context.LoanProducts.ToListAsync();
        }

        public async Task<LoanProduct> GetLoanProductByIdAsync(int loanProductId)
        {
            return await _context.LoanProducts
                .Include(lp => lp.Loans) // Include related loans
                .FirstOrDefaultAsync(lp => lp.LoanProductId == loanProductId);
        }

        public async Task AddLoanProductAsync(LoanProduct loanProduct)
        {
            _context.LoanProducts.Add(loanProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoanProductAsync(LoanProduct loanProduct)
        {
            _context.LoanProducts.Update(loanProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLoanProductAsync(int loanProductId)
        {
            var loanProduct = await _context.LoanProducts.FindAsync(loanProductId);
            if (loanProduct != null)
            {
                _context.LoanProducts.Remove(loanProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}

