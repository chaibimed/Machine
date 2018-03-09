using System.Threading.Tasks;
using MachineCafe.WebApi.Contracts;

namespace MachineCafe.Model
{
    /// <summary>
    /// In Real Case This class would comunicate with the machine's device responsible fro placing the mug
    /// </summary>
    public class MugPlacer : IMugPlacer
    {
        public Task SetNewGoblet()
        {
            return Task.FromResult(0);
        }
    }
}