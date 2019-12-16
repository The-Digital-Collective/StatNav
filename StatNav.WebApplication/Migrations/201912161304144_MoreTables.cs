namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExperimentIteration", "ExperimentProgrammeId", "dbo.ExperimentProgramme");
            DropForeignKey("dbo.ExperimentProgramme", "ExperimentStatusId", "dbo.ExperimentStatus");
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
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.ExperimentProgramme", "ProblemValidation", c => c.String());
            AddColumn("dbo.ExperimentProgramme", "Hypothesis", c => c.String());
            AddColumn("dbo.ExperimentProgramme", "Method", c => c.String());
            AddColumn("dbo.ExperimentProgramme", "TargetMetricModelId", c => c.Int(nullable: false));
            AddColumn("dbo.ExperimentProgramme", "TargetValue", c => c.Single(nullable: false));
            AddColumn("dbo.ExperimentProgramme", "ImpactMetricModelId", c => c.Int(nullable: false));
            AddColumn("dbo.ExperimentProgramme", "ImpactValue", c => c.Single(nullable: false));
            AddColumn("dbo.ExperimentProgramme", "SuccessOutcome", c => c.String());
            AddColumn("dbo.ExperimentProgramme", "FailureOutcome", c => c.String());
            AddColumn("dbo.ExperimentProgramme", "Notes", c => c.String());
            CreateIndex("dbo.ExperimentProgramme", "TargetMetricModelId");
            CreateIndex("dbo.ExperimentProgramme", "ImpactMetricModelId");
            AddForeignKey("dbo.ExperimentProgramme", "ImpactMetricModelId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "TargetMetricModelId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.ExperimentIteration", "ExperimentProgrammeId", "dbo.ExperimentProgramme", "Id");
            AddForeignKey("dbo.ExperimentProgramme", "ExperimentStatusId", "dbo.ExperimentStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExperimentProgramme", "ExperimentStatusId", "dbo.ExperimentStatus");
            DropForeignKey("dbo.ExperimentIteration", "ExperimentProgrammeId", "dbo.ExperimentProgramme");
            DropForeignKey("dbo.Team", "OrganisationId", "dbo.Organisation");
            DropForeignKey("dbo.ExperimentProgramme", "TargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentProgramme", "ImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.MetricModel", "MetricModelStageId", "dbo.MetricModelStage");
            DropIndex("dbo.Team", new[] { "OrganisationId" });
            DropIndex("dbo.MetricModel", new[] { "MetricModelStageId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "ImpactMetricModelId" });
            DropIndex("dbo.ExperimentProgramme", new[] { "TargetMetricModelId" });
            DropColumn("dbo.ExperimentProgramme", "Notes");
            DropColumn("dbo.ExperimentProgramme", "FailureOutcome");
            DropColumn("dbo.ExperimentProgramme", "SuccessOutcome");
            DropColumn("dbo.ExperimentProgramme", "ImpactValue");
            DropColumn("dbo.ExperimentProgramme", "ImpactMetricModelId");
            DropColumn("dbo.ExperimentProgramme", "TargetValue");
            DropColumn("dbo.ExperimentProgramme", "TargetMetricModelId");
            DropColumn("dbo.ExperimentProgramme", "Method");
            DropColumn("dbo.ExperimentProgramme", "Hypothesis");
            DropColumn("dbo.ExperimentProgramme", "ProblemValidation");
            DropTable("dbo.Team");
            DropTable("dbo.Organisation");
            DropTable("dbo.MetricModelStage");
            DropTable("dbo.MetricModel");
            AddForeignKey("dbo.ExperimentProgramme", "ExperimentStatusId", "dbo.ExperimentStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExperimentIteration", "ExperimentProgrammeId", "dbo.ExperimentProgramme", "Id", cascadeDelete: true);
        }
    }
}
