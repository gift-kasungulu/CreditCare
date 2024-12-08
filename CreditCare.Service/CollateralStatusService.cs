using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public class CollateralStatusService : ICollateralStatusService
    {
        private readonly ApplicationDbContext _context;

        public CollateralStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CollateralStatus>> GetAllAsync()
        {
            return await _context.CollateralStatus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CollateralStatus> GetByIdAsync(int id)
        {
            return await _context.CollateralStatus
                .FirstOrDefaultAsync(s => s.CollateralStatusId == id);
        }

        public async Task AddAsync(CollateralStatus collateralStatus)
        {
            // Ensure no existing status with the same name
            var existingStatus = await _context.CollateralStatus
                .FirstOrDefaultAsync(s => s.Name.ToLower() == collateralStatus.Name.ToLower());

            if (existingStatus != null)
            {
                throw new InvalidOperationException("A collateral status with this name already exists.");
            }

            _context.CollateralStatus.Add(collateralStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CollateralStatus collateralStatus)
        {
            var existing = await _context.CollateralStatus
                .FirstOrDefaultAsync(s => s.CollateralStatusId == collateralStatus.CollateralStatusId);

            if (existing == null)
            {
                throw new NotFoundException("Collateral status not found.");
            }

            existing.Name = collateralStatus.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var collateralStatus = await _context.CollateralStatus
                .FirstOrDefaultAsync(s => s.CollateralStatusId == id);

            if (collateralStatus == null)
            {
                throw new NotFoundException("Collateral status not found.");
            }

            _context.CollateralStatus.Remove(collateralStatus);
            await _context.SaveChangesAsync();
        }
    }

    // Custom exception for not found scenarios
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}