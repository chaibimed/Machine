using System.Data.Entity;

namespace MachineCafe.DataAccess
{

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString):base(connectionString ?? "default")
        {
        }

        public ApplicationContext() : base("default")
        {
        }

        public DbSet<MachineState> MachineState { get; set; }
        public DbSet<UserPreferences> UserPreferenceses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MachineState>().HasKey(p => p.TypeOfGrain);
            modelBuilder.Entity<UserPreferences>().HasKey(p => p.Type);
            base.OnModelCreating(modelBuilder);
        }
    }

   
}