using System.Collections.Generic;
using System.Threading.Tasks;
using MachineCafe.WebApi.Contracts;
using MachineCafe.WebApi.Models;

namespace MachineCafe.Model.DatabaseAccess
{
    public class EFRepository : IMachineRepository
    {
        private readonly ApplicationContext _ctxt;

        public EFRepository(ApplicationContext _ctxt)
        {
            this._ctxt = _ctxt;
        }
        public IEnumerable<KeyValuePair<GrainType, int>> GetLastState()
        {

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