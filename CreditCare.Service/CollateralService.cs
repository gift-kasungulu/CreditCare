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

        public async Task AddCollateralAsync(Collateral collateral)
        {
            _context.Collaterals.Add(collateral);
            await _context.SaveChangesAsync();
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
