using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineCafe.Business
{
    public interface IMachineRepository
    {
        IEnumerable<KeyValuePair<GrainType, int>> GetLastState();
        Task SaveState(IEnumerable<KeyValuePair<GrainType, int>> snapshot);
        Task SaveUserPreference(GrainType type, int sucre, bool selfMug);
    }
}