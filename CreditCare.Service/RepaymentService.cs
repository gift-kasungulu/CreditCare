using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;

public class RepaymentService
{
    private readonly ApplicationDbContext _context;

    public RepaymentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Repayment>> GetAllRepaymentsAsync()
    {
        return await _context.Repayments
            .Include(r => r.Loan) // Include related loan if needed
            .ToListAsync();
    }

    public async Task<decimal> CalculateTotalRepaymentAmountAsync()
    {
        return await _context.Repayments.SumAsync(r => r.Amount);
    }
}