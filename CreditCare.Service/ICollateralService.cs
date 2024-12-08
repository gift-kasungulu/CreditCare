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
        Task<Collateral> AddCollateralAsync(Collateral collateral); // Modified return type
        Task UpdateCollateralAsync(Collateral collateral);
        Task DeleteCollateralAsync(int collateralId);
    }
}
