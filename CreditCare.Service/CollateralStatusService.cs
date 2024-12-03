using CreditCare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCare.Service
{
    public class CollateralStatusService : ICollateralStatusService
    {
        private readonly List<CollateralStatus> _collateralStatuses = new List<CollateralStatus>();

        public Task<List<CollateralStatus>> GetAllAsync()
        {
            return Task.FromResult(_collateralStatuses);
        }

        public Task<CollateralStatus> GetByIdAsync(int id)
        {
            var collateralStatus = _collateralStatuses.FirstOrDefault(s => s.CollateralStatusId == id);
            return Task.FromResult(collateralStatus);
        }

        public Task AddAsync(CollateralStatus collateralStatus)
        {
            collateralStatus.CollateralStatusId = _collateralStatuses.Count + 1; // Simulate auto-increment ID
            _collateralStatuses.Add(collateralStatus);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(CollateralStatus collateralStatus)
        {
            var existing = _collateralStatuses.FirstOrDefault(s => s.CollateralStatusId == collateralStatus.CollateralStatusId);
            if (existing != null)
            {
                existing.Name = collateralStatus.Name;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var collateralStatus = _collateralStatuses.FirstOrDefault(s => s.CollateralStatusId == id);
            if (collateralStatus != null)
            {
                _collateralStatuses.Remove(collateralStatus);
            }
            return Task.CompletedTask;
        }
    }
}

