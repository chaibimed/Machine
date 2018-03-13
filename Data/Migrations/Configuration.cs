using System.Collections.Generic;
using MachineCafe.Model.MachineModel;

namespace MachineCafe.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        private readonly IEnumerable<MachineState> _machineState = new List<MachineState>
        {
            new MachineState(GrainType.Cafe, 0),
            new MachineState(GrainType.The, 0),
            new MachineState(GrainType.Sucre, 0),
            new MachineState(GrainType.Chocolat, 0)
        } ;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationContext context)
        {
            foreach (var state in _machineState)
            {
                context.MachineState.AddOrUpdate(m => m.TypeOfGrain, state);
            }

        }
    }
}
