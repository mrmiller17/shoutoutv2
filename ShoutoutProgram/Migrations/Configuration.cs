namespace ShoutoutProgram.Migrations
{
    using ShoutoutProgram.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
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
            context.Levels.AddOrUpdate(l => l.Id,
                new Level() { Id = 1, Name = "Good Job", Points = 1 },
                new Level() { Id = 2, Name = "Above & Beyond", Points = 2 },
                new Level() { Id = 3, Name = "By Team Lead", Points = 3 },
                new Level() { Id = 4, Name = "By Supervisor", Points = 4 },
                new Level() { Id = 5, Name = "By Client", Points = 5 }

                );
        }
    }
}
