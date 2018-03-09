using MachineCafe.WebApi.Models;

namespace MachineCafe.Model.DatabaseAccess
{
    public class MachineState
    {
        public MachineState()
        {
        }
        public MachineState(GrainType type, int amount)
        {
            this.TypeOfGrain = (int) type;
            this.Amount = amount;
        }
        public int TypeOfGrain { get;  }
        public int Amount { get;  }
    }
}