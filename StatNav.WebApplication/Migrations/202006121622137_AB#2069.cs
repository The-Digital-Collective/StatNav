namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AB2069 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExperimentProgramme", "ExperimentStatusId", "dbo.ExperimentStatus");
            DropForeignKey("dbo.ExperimentProgramme", "PackageContainerId", "dbo.PackageContainer");
            DropForeignKey("dbo.ExperimentProgramme", "ProgrammeImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentProgramme", "MethodId", "dbo.Method");
            DropForeignKey("dbo.ExperimentProgramme", "ProgrammeTargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentProgramme", "TeamId", "dbo.Team");
            DropForeignKey("dbo.ExperimentProgramme", "UserId", "dbo.User");
            DropForeignKey("dbo.ExperimentIteration", "ExperimentProgrammeId", "dbo.ExperimentProgramme");
            DropIndex("dbo.ExperimentIteration", new[] { "ExperimentProgrammeId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "UserId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "TeamId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "MethodId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "ProgrammeTargetMetricModelId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "ProgrammeImpactMetricModelId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "ExperimentStatusId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "PackageContainerId" });
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
                        PackageContainerId = c.Int(),
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
            
            AddColumn("dbo.ExperimentIteration", "MarketingAssetPackageId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExperimentIteration", "MarketingAssetPackageId");
            AddForeignKey("dbo.ExperimentIteration", "MarketingAssetPackageId", "dbo.MarketingAssetPackage", "Id");
            DropColumn("dbo.ExperimentIteration", "ExperimentProgrammeId");
            DropTable("dbo.ExperimentProgramme");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExperimentProgramme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        TeamId = c.Int(),
                        ProgrammeName = c.String(nullable: false),
                        Problem = c.String(),
                        ProblemValidation = c.String(),
                        Hypothesis = c.String(),
                        MethodId = c.Int(nullable: false),
                        ProgrammeTargetMetricModelId = c.Int(nullable: false),
                        TargetValue = c.Single(nullable: false),
                        ProgrammeImpactMetricModelId = c.Int(nullable: false),
                        ImpactValue = c.Single(nullable: false),
                        ExperimentStatusId = c.Int(nullable: false),
                        Notes = c.String(),
                        PackageContainerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExperimentIteration", "ExperimentProgrammeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ExperimentIteration", "MarketingAssetPackageId", "dbo.MarketingAssetPackage");
            DropForeignKey("dbo.MarketingAssetPackage", "UserId", "dbo.User");
            DropForeignKey("dbo.MarketingAssetPackage", "TeamId", "dbo.Team");
            DropForeignKey("dbo.MarketingAssetPackage", "PackageContainerId", "dbo.PackageContainer");
            DropForeignKey("dbo.MarketingAssetPackage", "MAPTargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.MarketingAssetPackage", "MethodId", "dbo.Method");
            DropForeignKey("dbo.MarketingAssetPackage", "MAPImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.MarketingAssetPackage", "ExperimentStatusId", "dbo.ExperimentStatus");
            DropIndex("dbo.MarketingAssetPackage", new[] { "PackageContainerId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "ExperimentStatusId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MAPImpactMetricModelId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MAPTargetMetricModelId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MethodId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "TeamId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "UserId" });
            DropIndex("dbo.ExperimentIteration", new[] { "MarketingAssetPackageId" });
            DropColumn("dbo.ExperimentIteration", "MarketingAssetPackageId");
            DropTable("dbo.MarketingAssetPackage");
            CreateIndex("dbo.ExperimentProgramme", "PackageContainerId");
            CreateIndex("dbo.ExperimentProgramme", "ExperimentStatusId");
            CreateIndex("dbo.ExperimentProgramme", "ProgrammeImpactMetricModelId");
            CreateIndex("dbo.ExperimentProgramme", "ProgrammeTargetMetricModelId");
            CreateIndex("dbo.ExperimentProgramme", "MethodId");
            CreateIndex("dbo.ExperimentProgramme", "TeamId");
            CreateIndex("dbo.ExperimentProgramme", "UserId");
            CreateIndex("dbo.ExperimentIteration", "ExperimentProgrammeId");
            AddForeignKey("dbo.ExperimentIteration", "ExperimentProgrammeId", "dbo.ExperimentProgramme", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "TeamId", "dbo.Team", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "ProgrammeTargetMetricModelId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "MethodId", "dbo.Method", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "ProgrammeImpactMetricModelId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "PackageContainerId", "dbo.PackageContainer", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "ExperimentStatusId", "dbo.ExperimentStatus", "Id");
        }
    }
}
