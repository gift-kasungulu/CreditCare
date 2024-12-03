using CreditCare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public interface ILoanStatusService
    {
        Task<List<LoanStatus>> GetAllAsync();
        Task<LoanStatus> GetByIdAsync(int id);
        Task AddAsync(LoanStatus loanStatus);
        Task UpdateAsync(LoanStatus loanStatus);
        Task DeleteAsync(int id);
    }
}
