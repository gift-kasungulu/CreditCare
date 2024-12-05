using CreditCare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public interface ICollateralService
    {
        Task<IEnumerable<Collateral>> GetAllCollateralsAsync();
        Task<Collateral?> GetCollateralByIdAsync(int collateralId);
        Task AddCollateralAsync(Collateral collateral);
        Task UpdateCollateralAsync(Collateral collateral);
        Task DeleteCollateralAsync(int collateralId);
    }
}
