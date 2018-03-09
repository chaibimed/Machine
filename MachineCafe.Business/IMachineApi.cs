using System.Threading.Tasks;

namespace MachineCafe.Business
{
    public interface IDeviceApi
    {
        Task TurnOn();
        Task TurnOff();
        Task MakeBeverage(GrainType type, int sugarAmount, bool SelfMug);
    }
}