namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CandidateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExperimentCandidate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExperimentIterationId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Control = c.Boolean(nullable: false),
                        TargetMetricModelId = c.Int(nullable: false),
                        TargetMet = c.Boolean(nullable: false),
                        ImpactMetricModelId = c.Int(nullable: false),
                        ImpactMet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExperimentIteration", t => t.ExperimentIterationId)
                .ForeignKey("dbo.MetricModel", t => t.ImpactMetricModelId)
                .ForeignKey("dbo.MetricModel", t => t.TargetMetricModelId)
                .Index(t => t.ExperimentIterationId)
                .Index(t => t.TargetMetricModelId)
                .Index(t => t.ImpactMetricModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExperimentCandidate", "TargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentCandidate", "ImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentCandidate", "ExperimentIterationId", "dbo.ExperimentIteration");
            DropIndex("dbo.ExperimentCandidate", new[] { "ImpactMetricModelId" });
            DropIndex("dbo.ExperimentCandidate", new[] { "TargetMetricModelId" });
            DropIndex("dbo.ExperimentCandidate", new[] { "ExperimentIterationId" });
            DropTable("dbo.ExperimentCandidate");
        }
    }
}
