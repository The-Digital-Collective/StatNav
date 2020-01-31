namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
 
    internal sealed class Configuration : DbMigrationsConfiguration<StatNav.WebApplication.DAL.StatNavContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StatNav.WebApplication.DAL.StatNavContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
