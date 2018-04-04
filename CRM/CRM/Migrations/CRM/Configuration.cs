using CRM.DAL;

namespace CRM.Migrations.CRM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.CrmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CRM";
        }

        protected override void Seed(DAL.CrmContext context)
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
            context.Sections.AddOrUpdate(
                s => s.SectionName, DummyData.getSections().ToArray());
            context.SaveChanges();

            context.Employees.AddOrUpdate(
                e => new { e.FirstName, e.LastName }, DummyData.getEmployee(context).ToArray());
            context.SaveChanges();
        }

    }
}
