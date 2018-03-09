using System.Threading.Tasks;
using MachineCafe.Business;
using MachineCafe.Business.Machine.Model;
using NUnit.Framework;

namespace MachineCafe.UnitTests.MachineTests
{
    [TestFixture]
    public class DeviceApiTests
    {
        [Test]
        public async Task GivenIHaveTheLastState_WhenITurnOnTheDevice_IShouldGetDetailsAboutItsCurrentState()
        {
            IMachineRepository repository; 
            IWaterSource source;
            IGrainStock piles;
            IMugPlacer placer;
            PhilipsMachineCafeApi machine = new PhilipsMachineCafeApi(source, piles, placer);
             await machine.TurnOn();
        }
    }
}