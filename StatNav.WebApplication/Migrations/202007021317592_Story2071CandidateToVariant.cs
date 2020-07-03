namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Story2071CandidateToVariant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExperimentCandidate", "CandidateImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentCandidate", "CandidateTargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.ExperimentCandidate", "ExperimentId", "dbo.Experiment");
            DropForeignKey("dbo.MetricCandidateResult", "ExperimentCandidateId", "dbo.ExperimentCandidate");
            DropForeignKey("dbo.MetricCandidateResult", "MetricId", "dbo.MetricModel");
            DropIndex("dbo.ExperimentCandidate", new[] { "ExperimentId" });
            DropIndex("dbo.ExperimentCandidate", new[] { "CandidateTargetMetricModelId" });
            DropIndex("dbo.ExperimentCandidate", new[] { "CandidateImpactMetricModelId" });
            DropIndex("dbo.MetricCandidateResult", new[] { "MetricId" });
            DropIndex("dbo.MetricCandidateResult", new[] { "ExperimentCandidateId" });
            CreateTable(
                "dbo.Variant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExperimentId = c.Int(nullable: false),
                        VariantName = c.String(nullable: false),
                        Control = c.Boolean(nullable: false),
                        VariantTargetMetricModelId = c.Int(nullable: false),
                        TargetMet = c.Boolean(nullable: false),
                        VariantImpactMetricModelId = c.Int(nullable: false),
                        ImpactMet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experiment", t => t.ExperimentId)
                .ForeignKey("dbo.MetricModel", t => t.VariantImpactMetricModelId)
                .ForeignKey("dbo.MetricModel", t => t.VariantTargetMetricModelId)
                .Index(t => t.ExperimentId)
                .Index(t => t.VariantTargetMetricModelId)
                .Index(t => t.VariantImpactMetricModelId);
            
            CreateTable(
                "dbo.MetricVariantResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MetricId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                        SampleSize = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MetricModel", t => t.MetricId)
                .ForeignKey("dbo.Variant", t => t.VariantId)
                .Index(t => t.MetricId)
                .Index(t => t.VariantId);
            
            DropTable("dbo.ExperimentCandidate");
            DropTable("dbo.MetricCandidateResult");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperimentCandidate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExperimentId = c.Int(nullable: false),
                        CandidateName = c.String(nullable: false),
                        Control = c.Boolean(nullable: false),
                        CandidateTargetMetricModelId = c.Int(nullable: false),
                        TargetMet = c.Boolean(nullable: false),
                        CandidateImpactMetricModelId = c.Int(nullable: false),
                        ImpactMet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.MetricVariantResult", "VariantId", "dbo.Variant");
            DropForeignKey("dbo.MetricVariantResult", "MetricId", "dbo.MetricModel");
            DropForeignKey("dbo.Variant", "VariantTargetMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.Variant", "VariantImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.Variant", "ExperimentId", "dbo.Experiment");
            DropIndex("dbo.MetricVariantResult", new[] { "VariantId" });
            DropIndex("dbo.MetricVariantResult", new[] { "MetricId" });
            DropIndex("dbo.Variant", new[] { "VariantImpactMetricModelId" });
            DropIndex("dbo.Variant", new[] { "VariantTargetMetricModelId" });
            DropIndex("dbo.Variant", new[] { "ExperimentId" });
            DropTable("dbo.MetricVariantResult");
            DropTable("dbo.Variant");
            CreateIndex("dbo.MetricCandidateResult", "ExperimentCandidateId");
            CreateIndex("dbo.MetricCandidateResult", "MetricId");
            CreateIndex("dbo.ExperimentCandidate", "CandidateImpactMetricModelId");
            CreateIndex("dbo.ExperimentCandidate", "CandidateTargetMetricModelId");
            CreateIndex("dbo.ExperimentCandidate", "ExperimentId");
            AddForeignKey("dbo.MetricCandidateResult", "MetricId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.MetricCandidateResult", "ExperimentCandidateId", "dbo.ExperimentCandidate", "Id");
            AddForeignKey("dbo.ExperimentCandidate", "ExperimentId", "dbo.Experiment", "Id");
            AddForeignKey("dbo.ExperimentCandidate", "CandidateTargetMetricModelId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.ExperimentCandidate", "CandidateImpactMetricModelId", "dbo.MetricModel", "Id");
        }
    }
}
