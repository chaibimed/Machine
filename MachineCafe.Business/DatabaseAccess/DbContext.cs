using System.Data.Entity;
using MachineCafe.WebApi.Models;

namespace MachineCafe.Model.DatabaseAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext():base("default")
        {
        }

        public DbSet<MachineState> MachineState { get; set; }
        public DbSet<UserPreferences> UserPreferenceses { get; set; }
    }

   
}