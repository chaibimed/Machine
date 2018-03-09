using System.Threading;
using System.Threading.Tasks;
using MachineCafe.WebApi.Contracts;

namespace MachineCafe.Model
{
    /// <summary>
    /// In Real Case This class would comunicate with the machine's device responsible for water service
    /// </summary>
    public class WaterSource : IWaterSource
    {
        public Task ConnectToSource()
        {
            return Task.FromResult(0);
        }

        public Task Pour()
        {
            var ts = new TaskCompletionSource<object>();
            Thread.Sleep(10);
            return ts.Task;
        }

        public Task DisconnectFromSource()
        {
            return Task.FromResult(0);
        }
    }
}