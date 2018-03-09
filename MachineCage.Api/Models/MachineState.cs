namespace MachineCafe.WebApi.Models
{
    public class MachineState
    {
        public int TypeOfGrain { get; set; }
        public int Amount { get; set; }
    }

    public class UserPreferences
    {
        public int Sucure { get; set; }
        public GrainType Type { get; set; }
        public bool SelfMug { get; set; }
    }
}