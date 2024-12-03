using CreditCare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public interface IInterestRateService
    {
        Task<List<InterestRate>> GetAllAsync();
        Task<InterestRate> GetByIdAsync(int id);
        Task AddAsync(InterestRate interestRate);
        Task UpdateAsync(InterestRate interestRate);
        Task DeleteAsync(int id);
    }
}
