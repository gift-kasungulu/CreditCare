using CreditCare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public interface ICollateralStatusService
    {
        Task<List<CollateralStatus>> GetAllAsync();
        Task<CollateralStatus> GetByIdAsync(int id);
        Task AddAsync(CollateralStatus collateralStatus);
        Task UpdateAsync(CollateralStatus collateralStatus);
        Task DeleteAsync(int id);
    }
}
