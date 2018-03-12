using System.Collections.Generic;
using System.Threading.Tasks;
using MachineCafe.Model;
using MachineCafe.Model.MachineModel;
using Moq;
using NUnit.Framework;

namespace MachineCafe.UnitTests.MachineTests
{
    [TestFixture]
    public class DeviceApiTests
    {
        [Test]
        public async Task TurningOnMachine_ShouldSeedStock_And_ConnectWaterSource()
        {
            var source = new Mock<IWaterSource>();
            var store = new Mock<IGrainStock>();
            var placer = new Mock<IMugPlacer>();
            PhilipsMachineCafeApi machine = new PhilipsMachineCafeApi(source.Object, store.Object, placer.Object);

            await machine.TurnOn(InitParameters());

            store.Verify(p => p.SupplyGrain(It.IsAny<GrainType>(), It.IsAny<int>()),Times.Exactly(4));
            source.Verify(p => p.ConnectToSource(),Times.Exactly(1));
        }

        [Test]
        public async Task GivenTheMachineIsOn_WhenTunOn_ShouldThrowInvalidOperation()
        {
            var machine = MakeMachine();
            await machine.TurnOn(InitParameters());
            Assert.That(async () => await machine.TurnOn(InitParameters()), Throws.InvalidOperationException);
        }

        [Test]
        public async Task TurningOffMachine_ShouldDisconnectrFromWaterSource_And_ReturnTheCurrentStateToBeSaved()
        {
            var source = new Mock<IWaterSource>();
            var store = new Mock<IGrainStock>();
            var placer = new Mock<IMugPlacer>();
            PhilipsMachineCafeApi machine = new PhilipsMachineCafeApi(source.Object, store.Object, placer.Object);

            await machine.TurnOn(InitParameters());
            var result = await machine.TurnOff();

            store.Verify(p => p.GetLevelOfStock(It.IsAny<GrainType>()), Times.Exactly(4));
            source.Verify(p => p.DisconnectFromSource(), Times.Exactly(1));
        }

        [Test]
        public async Task MakeCafeWithoutTurningOnMachineThrowExceptionTask()
        {
            var machine = MakeMachine();
            Assert.That(async() => await machine.MakeBeverage(GrainType.Cafe, 2,true),Throws.InvalidOperationException);
        }

        
        [Test]
        public async Task MakeBeverage_Should_PlaceMug_PourWater_Then_PourGrain()
        {
            var source = new Mock<IWaterSource>();
            var store = new Mock<IGrainStock>();
            var placer = new Mock<IMugPlacer>();
            PhilipsMachineCafeApi machine = new PhilipsMachineCafeApi(source.Object, store.Object, placer.Object);

            await machine.TurnOn(InitParameters());
            await machine.MakeBeverage(GrainType.Cafe, 2,false);

            store.Verify(p =>p.PoorGrain(GrainType.Cafe, 1));
            placer.Verify(p => p.SetNewGoblet(), Times.Exactly(1));
            source.Verify(p => p.Pour(), Times.Exactly(1));
        }

        [Test]
        public async Task GivenTheUserHasPlacedHisMug_MakeBeverage_Should_NotPlaceMug()
        {
            var source = new Mock<IWaterSource>();
            var store = new Mock<IGrainStock>();
            var placer = new Mock<IMugPlacer>();
            PhilipsMachineCafeApi machine = new PhilipsMachineCafeApi(source.Object, store.Object, placer.Object);

            await machine.TurnOn(InitParameters());
            await machine.MakeBeverage(GrainType.Cafe, 2, true);

            placer.Verify(p => p.SetNewGoblet(),Times.Never);
        }

        private static List<KeyValuePair<GrainType, int>> InitParameters()
        {
            return new List<KeyValuePair<GrainType, int>>()
            {
                new KeyValuePair<GrainType, int>(GrainType.Cafe, 10),
                new KeyValuePair<GrainType, int>(GrainType.The, 10),
                new KeyValuePair<GrainType, int>(GrainType.Chocolat, 10),
                new KeyValuePair<GrainType, int>(GrainType.Sucre, 20),

            };
        }

        private PhilipsMachineCafeApi MakeMachine()
        {
            var source = new Mock<IWaterSource>();
            var store = new Mock<IGrainStock>();
            var placer = new Mock<IMugPlacer>();
            return new PhilipsMachineCafeApi(source.Object, store.Object, placer.Object); 
        }
    }
}