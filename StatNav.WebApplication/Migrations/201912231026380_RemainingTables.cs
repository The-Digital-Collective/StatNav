namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemainingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Username = c.String(),
                        Shared = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .ForeignKey("dbo.UserRole", t => t.RoleId)
                .Index(t => t.TeamId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        ReadTeamProgrammes = c.Boolean(nullable: false),
                        EditTeamProgrammes = c.Boolean(nullable: false),
                        ReadOrganisationProgrammes = c.Boolean(nullable: false),
                        EditOrganisationProgrammes = c.Boolean(nullable: false),
                        Administrator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MetricCandidateResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MetricId = c.Int(nullable: false),
                        ExperimentCandidateId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                        SampleSize = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExperimentCandidate", t => t.ExperimentCandidateId)
                .ForeignKey("dbo.MetricModel", t => t.MetricId)
                .Index(t => t.MetricId)
                .Index(t => t.ExperimentCandidateId);
            
            AddColumn("dbo.ExperimentProgramme", "UserId", c => c.Int());
            AddColumn("dbo.ExperimentProgramme", "TeamId", c => c.Int());
            CreateIndex("dbo.ExperimentProgramme", "UserId");
            CreateIndex("dbo.ExperimentProgramme", "TeamId");
            AddForeignKey("dbo.ExperimentProgramme", "TeamId", "dbo.Team", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetricCandidateResult", "MetricId", "dbo.MetricModel");
            DropForeignKey("dbo.MetricCandidateResult", "ExperimentCandidateId", "dbo.ExperimentCandidate");
            DropForeignKey("dbo.ExperimentProgramme", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.UserRole");
            DropForeignKey("dbo.User", "TeamId", "dbo.Team");
            DropForeignKey("dbo.ExperimentProgramme", "TeamId", "dbo.Team");
            DropIndex("dbo.MetricCandidateResult", new[] { "ExperimentCandidateId" });
            DropIndex("dbo.MetricCandidateResult", new[] { "MetricId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.User", new[] { "TeamId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "TeamId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "UserId" });
            DropColumn("dbo.ExperimentProgramme", "TeamId");
            DropColumn("dbo.ExperimentProgramme", "UserId");
            DropTable("dbo.MetricCandidateResult");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
        }
    }
}
