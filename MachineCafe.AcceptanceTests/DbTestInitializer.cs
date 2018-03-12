using System.Data.Entity;
using MachineCafe.DataAccess;

namespace MachineCafe.AcceptanceTests
{
    public class DbTestInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            base.Seed(context);
        }
    }
}