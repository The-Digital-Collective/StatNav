namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Reinitialise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExperimentCandidate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExperimentIterationId = c.Int(nullable: false),
                        CandidateName = c.String(nullable: false),
                        Control = c.Boolean(nullable: false),
                        CandidateTargetMetricModelId = c.Int(nullable: false),
                        TargetMet = c.Boolean(nullable: false),
                        CandidateImpactMetricModelId = c.Int(nullable: false),
                        ImpactMet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MetricModel", t => t.CandidateImpactMetricModelId)
                .ForeignKey("dbo.MetricModel", t => t.CandidateTargetMetricModelId)
                .ForeignKey("dbo.ExperimentIteration", t => t.ExperimentIterationId)
                .Index(t => t.ExperimentIterationId)
                .Index(t => t.CandidateTargetMetricModelId)
                .Index(t => t.CandidateImpactMetricModelId);
            
            CreateTable(
                "dbo.MetricModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MetricModelStageId = c.Int(nullable: false),
                        Title = c.String(),
                        GoodIsUp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MetricModelStage", t => t.MetricModelStageId)
                .Index(t => t.MetricModelStageId);
            
            CreateTable(
                "dbo.MetricModelStage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SortOrder = c.Int(nullable: false),
                        Title = c.String(),
                        DataType = c.Int(nullable: false),
                        MarketingModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperimentIteration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarketingAssetPackageId = c.Int(nullable: false),
                        IterationName = c.String(nullable: false),
                        RequiredDurationForSignificance = c.String(),
                        IterationNumber = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        SuccessOutcome = c.String(),
                        FailureOutcome = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MarketingAssetPackage", t => t.MarketingAssetPackageId)
                .Index(t => t.MarketingAssetPackageId);
            
            CreateTable(
                "dbo.MarketingAssetPackage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        TeamId = c.Int(),
                        MAPName = c.String(nullable: false),
                        Problem = c.String(),
                        ProblemValidation = c.String(),
                        Hypothesis = c.String(),
                        MethodId = c.Int(nullable: false),
                        MAPTargetMetricModelId = c.Int(nullable: false),
                        TargetValue = c.Single(nullable: false),
                        MAPImpactMetricModelId = c.Int(nullable: false),
                        ImpactValue = c.Single(nullable: false),
                        ExperimentStatusId = c.Int(nullable: false),
                        Notes = c.String(),
                        PackageContainerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExperimentStatus", t => t.ExperimentStatusId)
                .ForeignKey("dbo.MetricModel", t => t.MAPImpactMetricModelId)
                .ForeignKey("dbo.Method", t => t.MethodId)
                .ForeignKey("dbo.MetricModel", t => t.MAPTargetMetricModelId)
                .ForeignKey("dbo.PackageContainer", t => t.PackageContainerId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TeamId)
                .Index(t => t.MethodId)
                .Index(t => t.MAPTargetMetricModelId)
                .Index(t => t.MAPImpactMetricModelId)
                .Index(t => t.ExperimentStatusId)
                .Index(t => t.PackageContainerId);
            
            CreateTable(
                "dbo.ExperimentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Method",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SortOrder = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageContainer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageContainerName = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        MetricModelStageId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MetricModelStage", t => t.MetricModelStageId)
                .Index(t => t.MetricModelStageId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganisationId = c.Int(nullable: false),
                        TeamName = c.String(),
                        Shared = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisation", t => t.OrganisationId)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Organisation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganisationName = c.String(),
                        Shared = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetricCandidateResult", "MetricId", "dbo.MetricModel");
            DropForeignKey("dbo.MetricCandidateResult", "ExperimentCandidateId", "dbo.ExperimentCandidate");
            DropForeignKey("dbo.ExperimentIteration", "MarketingAssetPackageId", "dbo.MarketingAssetPackage");
            DropForeignKey("dbo.MarketingAssetPackage", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.UserRole");
            DropForeignKey("dbo.User", "TeamId", "dbo.Team");
            DropForeignKey("dbo.MarketingAssetPackage", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "OrganisationId", "dbo.Organisation");
            DropForeignKey("dbo.MarketingAssetPackage", "PackageContainerId", "dbo.PackageContainer");
            DropForeignKey("dbo.PackageContainer", "MetricModelStageId", "dbo.MetricModelStage");
            DropForeignKey("dbo.MarketingAssetPackage", "MAPTargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.MarketingAssetPackage", "MethodId", "dbo.Method");
            DropForeignKey("dbo.MarketingAssetPackage", "MAPImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.MarketingAssetPackage", "ExperimentStatusId", "dbo.ExperimentStatus");
            DropForeignKey("dbo.ExperimentCandidate", "ExperimentIterationId", "dbo.ExperimentIteration");
            DropForeignKey("dbo.ExperimentCandidate", "CandidateTargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentCandidate", "CandidateImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.MetricModel", "MetricModelStageId", "dbo.MetricModelStage");
            DropIndex("dbo.MetricCandidateResult", new[] { "ExperimentCandidateId" });
            DropIndex("dbo.MetricCandidateResult", new[] { "MetricId" });
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.User", new[] { "TeamId" });
            DropIndex("dbo.Team", new[] { "OrganisationId" });
            DropIndex("dbo.PackageContainer", new[] { "MetricModelStageId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "PackageContainerId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "ExperimentStatusId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MAPImpactMetricModelId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MAPTargetMetricModelId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MethodId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "TeamId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "UserId" });
            DropIndex("dbo.ExperimentIteration", new[] { "MarketingAssetPackageId" });
            DropIndex("dbo.MetricModel", new[] { "MetricModelStageId" });
            DropIndex("dbo.ExperimentCandidate", new[] { "CandidateImpactMetricModelId" });
            DropIndex("dbo.ExperimentCandidate", new[] { "CandidateTargetMetricModelId" });
            DropIndex("dbo.ExperimentCandidate", new[] { "ExperimentIterationId" });
            DropTable("dbo.MetricCandidateResult");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.Organisation");
            DropTable("dbo.Team");
            DropTable("dbo.PackageContainer");
            DropTable("dbo.Method");
            DropTable("dbo.ExperimentStatus");
            DropTable("dbo.MarketingAssetPackage");
            DropTable("dbo.ExperimentIteration");
            DropTable("dbo.MetricModelStage");
            DropTable("dbo.MetricModel");
            DropTable("dbo.ExperimentCandidate");
        }
    }
}
