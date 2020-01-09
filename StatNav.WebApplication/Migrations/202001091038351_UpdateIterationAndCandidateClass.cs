namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIterationAndCandidateClass : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ExperimentCandidate", name: "ImpactMetricModelId", newName: "CandidateImpactMetricModelId");
            RenameColumn(table: "dbo.ExperimentCandidate", name: "TargetMetricModelId", newName: "CandidateTargetMetricModelId");
            RenameIndex(table: "dbo.ExperimentCandidate", name: "IX_TargetMetricModelId", newName: "IX_CandidateTargetMetricModelId");
            RenameIndex(table: "dbo.ExperimentCandidate", name: "IX_ImpactMetricModelId", newName: "IX_CandidateImpactMetricModelId");
            RenameColumn(table: "dbo.ExperimentCandidate", name: "Name", newName: "CandidateName");
            RenameColumn(table: "dbo.ExperimentIteration", name: "Name", newName: "IterationName");

        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.ExperimentCandidate", name: "CandidateName", newName: "Name");
            RenameColumn(table: "dbo.ExperimentIteration", name: "IterationName", newName: "Name");
            RenameIndex(table: "dbo.ExperimentCandidate", name: "IX_CandidateImpactMetricModelId", newName: "IX_ImpactMetricModelId");
            RenameIndex(table: "dbo.ExperimentCandidate", name: "IX_CandidateTargetMetricModelId", newName: "IX_TargetMetricModelId");
            RenameColumn(table: "dbo.ExperimentCandidate", name: "CandidateTargetMetricModelId", newName: "TargetMetricModelId");
            RenameColumn(table: "dbo.ExperimentCandidate", name: "CandidateImpactMetricModelId", newName: "ImpactMetricModelId");
        }
    }
}
