using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class StatNavContext: DbContext
    {
        public StatNavContext() : base("WebAppContext")
        {
        }

        public DbSet<MarketingAssetPackage> MarketingAssetPackages { get; set; }
        public DbSet<ExperimentStatus> ExperimentStatuses { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MetricModel> MetricModels { get; set; }
        public DbSet<MetricModelStage> MetricModelStages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<MetricVariantResult> MetricVariantResults { get; set; }
        public DbSet<Method> Method { get; set; }
        public DbSet<PackageContainer> PackageContainer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}