using MachineCafe.Model.MachineModel;

namespace MachineCafe.DataAccess
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
        public int TypeOfGrain { get; private set; }
        public int Amount { get; private set; }
    }
}