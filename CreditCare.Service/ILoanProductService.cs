using CreditCare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public interface ILoanProductService
    {
        Task<IEnumerable<LoanProduct>> GetAllLoanProductsAsync();
        Task<LoanProduct> GetLoanProductByIdAsync(int loanProductId);
        Task AddLoanProductAsync(LoanProduct loanProduct);
        Task UpdateLoanProductAsync(LoanProduct loanProduct);
        Task DeleteLoanProductAsync(int loanProductId);
    }
}
