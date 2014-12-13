using Catering.Data.Models;

namespace Catering.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CateringContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CateringContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Users.AddOrUpdate(
                  p => p.FirstName,
                  new User { FirstName = "Rene Jezrael",LastName="Lopez Cano" ,Type = User.UserType.Admin,Username = "renelopezcano",Password = "renerene"},
                  new User { FirstName = "Brice",LastName="Lambson",Username="brinceLambson",Password="brincebrince", Type = User.UserType.Normal },
                  new User { FirstName = "Rowan",LastName="Miller",Username="rowanMiller",Password="rowanMiller", Type = User.UserType.Normal }
                );
            //
        }
    }
}
