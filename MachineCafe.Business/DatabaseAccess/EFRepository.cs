using System.Collections.Generic;
using System.Threading.Tasks;
using MachineCafe.WebApi.Contracts;
using MachineCafe.WebApi.Models;

namespace MachineCafe.Model.DatabaseAccess
{
    public class EFRepository : IMachineRepository
    {
        public IEnumerable<KeyValuePair<GrainType, int>> GetLastState()
        {
            throw new System.NotImplementedException();
        }

        public Task SaveState(IEnumerable<KeyValuePair<GrainType, int>> snapshot)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveUserPreference(GrainType type, int sucre, bool selfMug)
        {
            throw new System.NotImplementedException();
        }
    }
}