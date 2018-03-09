using System.Data.Entity;

namespace MachineCafe.Model.DatabaseAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext():base("default")
        {
        }

        public DbSet<MachineState> MachineState { get; set; } 
    }

    public class MachineState
    {

    }
}