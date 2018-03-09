using System.Threading.Tasks;

namespace MachineCafe.WebApi.Contracts
{
    public interface IWaterSource
    {
        Task ConnectToSource();
        Task Pour();
        Task DisconnectFromSource();
    }
}