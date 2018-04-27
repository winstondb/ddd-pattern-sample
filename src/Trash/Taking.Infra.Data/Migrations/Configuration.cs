using System.Data.Entity.Migrations;
using Taking.Infra.Data.Context;

namespace Taking.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TakingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TakingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
