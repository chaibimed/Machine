using System.Threading.Tasks;

namespace MachineCafe.WebApi.Contracts
{
    public interface IMugPlacer
    {
        Task SetNewGoblet();
    }
}