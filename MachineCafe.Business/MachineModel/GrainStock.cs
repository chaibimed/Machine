using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachineCafe.Model.MachineModel
{
    public class GrainStock : IGrainStock
    {
        private readonly ConcurrentDictionary<GrainType, int> _piles;

        public GrainStock(IEnumerable<KeyValuePair<GrainType,int>> seed)
        {
            this._piles = new ConcurrentDictionary<GrainType, int>(seed);
        }

        public Task PoorGrain(GrainType type, int dosage)
        {
            return PoorGrain(type, CancellationToken.None, dosage);
        }

        public Task PoorGrain(GrainType type, CancellationToken ct, int dosage = 1)
        {
            //I used here a thread safe operation that compares and then substruct
           _piles.AddOrUpdate(type, 0, (key, currentValue) =>
           {
               if (currentValue < dosage)
                   throw new InvalidOperationException(Properties.Resources.EmptySource);
               else
                   return currentValue - dosage;
           });
            return Task.FromResult(0);
        }

        public Task<int> GetLevelOfStock(GrainType type)
        {
            return Task.FromResult(_piles[type]);
        }

        public Task SupplyGrain(GrainType type, int quantity)
        {
            _piles[type] += quantity;
            return Task.FromResult(0);
        }
    }
}