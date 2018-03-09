using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MachineCafe.Business;
using MachineCafe.Business.Machine.Model;
using NUnit.Framework;

namespace MachineCafe.UnitTests.MachineTests
{
    [TestFixture]
    public class DeviceStockTests
    {
        [Test]
        public void GivenTheStockIsEmpty_WhenIPour_IShouldGetAnException()
        {
            var stock = new GrainStock(new List<KeyValuePair<GrainType, int>>());
            Assert.That(() => stock.PoorGrain(GrainType.Cafe, CancellationToken.None), Throws.InvalidOperationException);
        }

        [TestCase(GrainType.Cafe)]
        [TestCase(GrainType.The)]
        [TestCase(GrainType.Chocolat)]

        public async Task GivenTheStockIsFilled_WhenPouring_SholdUpdateStock(GrainType type)
        {
            var stock = MakeAndSeedStock(type, 10);
            await stock.PoorGrain(type, 2);
            var remained = await stock.GetLevelOfStock(type);
            Assert.That(remained, Is.EqualTo(8));
        }

        [Test]
        public async Task GivenThereIsNoMoreStockOfAnItem_WhenTryingToPour_ShouldThrowInvalidOperationException()
        {
            var stock = MakeAndSeedStock(GrainType.Cafe, 2);
            Assert.That(() => stock.PoorGrain(GrainType.Cafe, 4), Throws.InvalidOperationException);
        }

        [TestCase(GrainType.Cafe)]
        [TestCase(GrainType.The)]
        [TestCase(GrainType.Chocolat)]
        public async Task GetLevelOfStock_ShouldReturnsTheActualLevelOfStock(GrainType type)
        {
            var stock = MakeAndSeedStock(type, 10);
            await stock.PoorGrain(type, 2);
            await stock.PoorGrain(type, 2);
            var remained = await stock.GetLevelOfStock(type);
            Assert.That(remained,Is.EqualTo(6));
        }

        [TestCase(GrainType.Cafe)]
        [TestCase(GrainType.The)]
        [TestCase(GrainType.Chocolat)]
        public async Task SupplyStock_ShouldIncreaseTheLevelOfStock(GrainType type)
        {
            var stock = MakeAndSeedStock(type, 2);
            await stock.SupplyGrain(type, 2);
            await stock.SupplyGrain(type, 2);
            var remained = await stock.GetLevelOfStock(type);
            Assert.That(remained, Is.EqualTo(6));
        }


        private static GrainStock MakeAndSeedStock(GrainType type, int amount)
        {
            var stock = new GrainStock(new List<KeyValuePair<GrainType, int>>()
            {
                new KeyValuePair<GrainType, int>(type, amount)
            });
            return stock;
        }
    }
}