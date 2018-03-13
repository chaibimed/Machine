using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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
        public async Task<IEnumerable<KeyValuePair<GrainType, int>>> GetLastState()
        {
           var states = await this._ctxt.MachineState.ToListAsync();
            var currentState = new List<KeyValuePair<GrainType,int>>();
            foreach (var state in states)
            {
                currentState.Add(new KeyValuePair<GrainType, int>((GrainType)state.TypeOfGrain, state.Amount));
            }
            return currentState;
        }

        public Task SaveState(IEnumerable<KeyValuePair<GrainType, int>> snapshot)
        {
            this._ctxt.MachineState.AddRange(snapshot.Select(p => new MachineState(p.Key, p.Value)));
            return _ctxt.SaveChangesAsync();
        }

        public async Task SaveUserPreference(GrainType type, int sucre, bool selfMug)
        {
          var pref = await _ctxt.UserPreferenceses.FirstOrDefaultAsync();
            if (pref == null)
                _ctxt.UserPreferenceses.Add(new UserPreferences(type, sucre, selfMug));
            else
            {
                pref.Update(type, sucre, selfMug);
                _ctxt.Entry(pref).State = EntityState.Modified;
            }
            await _ctxt.SaveChangesAsync();
        }
    }
}