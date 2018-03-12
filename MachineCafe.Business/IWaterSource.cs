using System.Threading.Tasks;

namespace MachineCafe.Model
{
    public interface IWaterSource
    {
        Task ConnectToSource();
        Task Pour();
        Task DisconnectFromSource();
    }
}