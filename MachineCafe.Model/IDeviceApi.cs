﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MachineCafe.Model.MachineModel;

namespace MachineCafe.Model
{
    public interface IDeviceApi
    {
        Task TurnOn(IEnumerable<KeyValuePair<GrainType, int>> initializationParameter);
        Task<IEnumerable<KeyValuePair<GrainType, int>>> TurnOff();
        Task MakeBeverage(GrainType type, int sugarAmount, bool SelfMug);
    }
}