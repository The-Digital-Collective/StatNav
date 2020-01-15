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

        public DbSet<ExperimentProgramme> ExperimentProgrammes { get; set; }
        public DbSet<ExperimentStatus> ExperimentStatuses { get; set; }
        public DbSet<ExperimentIteration> ExperimentIterations { get; set; }
        public DbSet<ExperimentCandidate> ExperimentCandidates { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MetricModel> MetricModels { get; set; }
        public DbSet<MetricModelStage> MetricModelStages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<MetricCandidateResult> MetricCandidateResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}