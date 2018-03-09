using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MachineCafe.WebApi.Contracts;
using MachineCafe.WebApi.Models;

namespace MachineCafe.Model
{
    public class PhilipsMachineCafeApi : IDeviceApi
    {
        private readonly IWaterSource source;
        private readonly IGrainStock piles;
        private readonly IMugPlacer placer;
        private bool _isOn;

        public PhilipsMachineCafeApi(IWaterSource source, IGrainStock piles, IMugPlacer placer)
        {
            this.source = source;
            this.piles = piles;
            this.placer = placer;
        }

        public async Task TurnOn(IEnumerable<KeyValuePair<GrainType, int>> initValues)
        {
            if (this._isOn)
                throw new InvalidOperationException(Properties.Resources.AlreadyOn);
            foreach (var seed in initValues)
            {
                await piles.SupplyGrain(seed.Key, seed.Value);
            }
            await source.ConnectToSource();
            this._isOn = true;
        }

        public async Task<IEnumerable<KeyValuePair<GrainType, int>>> TurnOff()
        {
            await this.source.DisconnectFromSource();
            var stateSnapshot = new List<KeyValuePair<GrainType, int>>();
            stateSnapshot.Add(GetItem(GrainType.Cafe));
            stateSnapshot.Add(GetItem(GrainType.Sucre));
            stateSnapshot.Add(GetItem(GrainType.Chocolat));
            stateSnapshot.Add(GetItem(GrainType.The));
            this._isOn = false;
            return stateSnapshot;
        }

        private  KeyValuePair<GrainType, int> GetItem(GrainType type)
        {
            return new KeyValuePair<GrainType, int>(type, this.piles.GetLevelOfStock(type).Result);
        }

        public async Task MakeBeverage(GrainType type, int sugarAmount, bool SelfMug)
        {
            if(!this._isOn)
                throw new InvalidOperationException(Properties.Resources.MustBeOn);

            if (!SelfMug)
                await this.placer.SetNewGoblet();
             await this.source.Pour();
             await this.piles.PoorGrain(type, 1);
        }
    }
}