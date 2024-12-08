using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public class CollateralService : ICollateralService
    {
        private readonly ApplicationDbContext _context;

        public CollateralService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Collateral>> GetAllCollateralsAsync()
        {
            return await _context.Collaterals
                .Include(c => c.collateralStatus)
                .Include(c => c.Loan)
                .ToListAsync();
        }

        public async Task<Collateral?> GetCollateralByIdAsync(int collateralId)
        {
            return await _context.Collaterals
                .Include(c => c.collateralStatus)
                .Include(c => c.Loan)
                .FirstOrDefaultAsync(c => c.CollateralId == collateralId);
        }

        public async Task<Collateral> AddCollateralAsync(Collateral collateral)
        {
            try
            {
                // Validate input
                if (collateral == null)
                    throw new ArgumentNullException(nameof(collateral), "Collateral cannot be null");

                // Ensure required fields are not null or default
                if (string.IsNullOrWhiteSpace(collateral.Description))
                    throw new ArgumentException("Description is required");

                if (collateral.Value <= 0)
                    throw new ArgumentException("Collateral value must be greater than zero");

                if (collateral.LoanId <= 0)
                    throw new ArgumentException("Invalid Loan ID");

                if (collateral.CollateralStatusId <= 0)
                    throw new ArgumentException("Invalid Collateral Status ID");

                // Explicitly load and validate related entities
                var loan = await _context.Loans
                    .FirstOrDefaultAsync(l => l.LoanId == collateral.LoanId);
                if (loan == null)
                    throw new ArgumentException($"Loan with ID {collateral.LoanId} not found");

                var status = await _context.CollateralStatus
                    .FirstOrDefaultAsync(s => s.CollateralStatusId == collateral.CollateralStatusId);
                if (status == null)
                    throw new ArgumentException($"Collateral Status with ID {collateral.CollateralStatusId} not found");

                // Attach related entities
                collateral.Loan = loan;
                collateral.collateralStatus = status;

                // Add and save
                _context.Collaterals.Add(collateral);
                await _context.SaveChangesAsync();

                return collateral;
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed inner exception
                // You might want to use a proper logging framework here
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                throw new Exception("Failed to save collateral. Please check the data and try again.", ex);
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.WriteLine($"Exception in AddCollateralAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCollateralAsync(Collateral collateral)
        {
            _context.Collaterals.Update(collateral);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCollateralAsync(int collateralId)
        {
            var collateral = await _context.Collaterals.FindAsync(collateralId);
            if (collateral != null)
            {
                _context.Collaterals.Remove(collateral);
                await _context.SaveChangesAsync();
            }
        }
    }
}
