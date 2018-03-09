using System.Threading.Tasks;

namespace MachineCafe.Business.Machine.Model
{
    public class PhilipsMachineCafeApi : IDeviceApi
    {
        private IWaterSource source;
        private IGrainStock piles;
        private IMugPlacer placer;

        public PhilipsMachineCafeApi(IWaterSource source, IGrainStock piles, IMugPlacer placer)
        {
            this.source = source;
            this.piles = piles;
            this.placer = placer;
        }

        public Task TurnOn()
        {
            throw new System.NotImplementedException();
        }

        public Task TurnOff()
        {
            throw new System.NotImplementedException();
        }

        public Task MakeBeverage(GrainType type, int sugarAmount, bool SelfMug)
        {
            throw new System.NotImplementedException();
        }
    }
}