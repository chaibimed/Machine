using System.Threading.Tasks;

namespace MachineCafe.Business
{
    public interface IWaterSource
    {
        Task ConnectToSource();
        Task Pour();
        Task DisconnectFromSource();
    }
}