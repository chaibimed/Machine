using System.Threading;
using System.Threading.Tasks;
using MachineCafe.Model.MachineModel;

namespace MachineCafe.Model
{
    public interface IGrainStock
    {
        Task PoorGrain(GrainType type, int dosage);
        Task PoorGrain(GrainType type, CancellationToken ct , int dosage);
        Task<int> GetLevelOfStock(GrainType type);
        Task SupplyGrain(GrainType type, int quantity); 
    }
}