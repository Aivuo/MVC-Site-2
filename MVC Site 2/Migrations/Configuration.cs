namespace MVC_Site_2.Migrations
{
    using MVC_Site_2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Site_2.Models.MovieDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MVC_Site_2.Models.MovieDb";
        }

        protected override void Seed(MVC_Site_2.Models.MovieDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Movies.AddOrUpdate(m => m.Name, 
            //    new Movie { Name = "Aladdin", ReleaseYear = 1992, Rating = 8, Price = 79.00F },
            //    new Movie { Name = "The Lion King", ReleaseYear = 1994, Rating = 9, Price = 129.00F },
            //    new Movie { Name = "Beuty and the Beast", ReleaseYear = 1991, Rating = 8, Price = 79.00F });
        }
    }
}
