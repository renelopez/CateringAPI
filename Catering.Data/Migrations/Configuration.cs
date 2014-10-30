using Catering.Data.Models;

namespace Catering.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Catering.Data.DataLayer.CateringContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Catering.Data.DataLayer.CateringContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Users.AddOrUpdate(
                  p => p.FirstName,
                  new User { FirstName = "Rene Lopez" },
                  new User { FirstName = "Brice Lambson" },
                  new User { FirstName = "Rowan Miller" }
                );
            //
        }
    }
}
