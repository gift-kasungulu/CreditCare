using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public class LoanStatusService : ILoanStatusService
    {
        private readonly ApplicationDbContext _context;

        public LoanStatusService(ApplicationDbContext context)
        {
                _context = context;
        }
        //private readonly List<LoanStatus> _loanStatuses = new List<LoanStatus>();

        public async Task<List<LoanStatus>> GetAllAsync()
        {
            return await _context.LoanStatuses.ToListAsync();
        }

        public async Task<LoanStatus> GetByIdAsync(int id)
        {
            return await _context.LoanStatuses.FirstOrDefaultAsync(c => c.LoanStatusId == id);
        }

        public Task AddAsync(LoanStatus loanStatus)
        {
           _context.LoanStatuses.Add(loanStatus);
           return _context.SaveChangesAsync();

        }

        public Task UpdateAsync(LoanStatus loanStatus)
        {
            var existing = _context.LoanStatuses.FirstOrDefault(s => s.LoanStatusId == loanStatus.LoanStatusId);
            if (existing != null)
            {
                existing.Name = loanStatus.Name;
            }
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var loanstatus = await _context.LoanStatuses.FindAsync(id);
            if (loanstatus != null)
            {
                _context.LoanStatuses.Remove(loanstatus); await _context.SaveChangesAsync();
            }
        }

    }
}
