using System;
using System.Linq;
using System.Reflection;
using MachineCafe.DataAccess;
using MachineCafe.Model;
using MachineCafe.Model.MachineModel;
using MachineCafe.WebApi.Controllers;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace MachineCafe.WebApi.Infrastructure
{
    public class SingletonServiceRegistrations : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IDeviceApi>().To<PhilipsMachineCafeApi>().InSingletonScope();
            this.Kernel.Bind<IMugPlacer>().To<MugPlacer>().InSingletonScope();
            this.Kernel.Bind<IWaterSource>().To<WaterSource>().InSingletonScope();
            this.Kernel.Bind<IGrainStock>().To<GrainStock>().InSingletonScope();
    }
    }
    public class ScopedServiceRegistration : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IMachineRepository>().To<EFRepository>().InSingletonScope();
        }
    }

}