using MachineCafe.WebApi.Models;

namespace MachineCafe.Model.DatabaseAccess
{
    public class UserPreferences
    {
        public UserPreferences()
        {
        }

        public UserPreferences(GrainType type, int sucreAmount, bool useMyMug)
        {
            this.Type = (int)type;
            this.Sucre = sucreAmount;
            this.SelfMug = useMyMug;
        }
        public int Type { get; private set; }
        public int Sucre { get; private set; }
        public bool SelfMug { get; private set; }

        public void Update(GrainType type, int sucre, bool selfMug)
        {
            this.Type = (int)type;
            this.Sucre = sucre;
            this.SelfMug = selfMug;
        }
    }
}