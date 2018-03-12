using System.Collections.Generic;
using System.Threading.Tasks;
using MachineCafe.Model.MachineModel;

namespace MachineCafe.DataAccess
{
    public interface IMachineRepository
    {
        Task<IEnumerable<KeyValuePair<GrainType, int>>> GetLastState();
        Task SaveState(IEnumerable<KeyValuePair<GrainType, int>> snapshot);
        Task SaveUserPreference(GrainType type, int sucre, bool selfMug);
    }
}