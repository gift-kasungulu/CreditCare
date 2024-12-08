using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public class InterestRateService : IInterestRateService
    {
        private readonly ApplicationDbContext _context;

        public InterestRateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InterestRate>> GetAllAsync()
        {
            return await _context.IRates.ToListAsync();
        }

        public async Task<InterestRate> GetByIdAsync(int id)
        {
            return await _context.IRates.FirstOrDefaultAsync(i => i.InterestRateId == id);
        }

        public async Task AddAsync(InterestRate interestRate)
        {
            await _context.IRates.AddAsync(interestRate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InterestRate interestRate)
        {
            var existing = await _context.IRates
                .FirstOrDefaultAsync(i => i.InterestRateId == interestRate.InterestRateId);

            if (existing == null)
            {
                throw new NotFoundException("Interest rate not found.");
            }

            existing.Rate = interestRate.Rate;
            existing.Description = interestRate.Description;
            existing.Term = interestRate.Term;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var interestRate = await _context.IRates.FirstOrDefaultAsync(r => r.InterestRateId == id);
            if (interestRate != null)
            {
                _context.IRates.Remove(interestRate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
