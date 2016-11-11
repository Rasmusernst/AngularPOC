namespace AngularPOC.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularPOC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularPOC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var placeholderBooks = new List<Books>
            {
                new Books() { Id = 1, BookName = "Book1" },
                new Books() { Id = 2, BookName = "Book2" },
                new Books() { Id = 3, BookName = "Book3" }

            };
            placeholderBooks.ForEach(s => context.Books.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();




        }
    }
}
