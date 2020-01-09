namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProgrammeClass : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ExperimentProgramme", name: "ImpactMetricModelId", newName: "ProgrammeImpactMetricModelId");
            RenameColumn(table: "dbo.ExperimentProgramme", name: "TargetMetricModelId", newName: "ProgrammeTargetMetricModelId");
            RenameIndex(table: "dbo.ExperimentProgramme", name: "IX_TargetMetricModelId", newName: "IX_ProgrammeTargetMetricModelId");
            RenameIndex(table: "dbo.ExperimentProgramme", name: "IX_ImpactMetricModelId", newName: "IX_ProgrammeImpactMetricModelId");
            RenameColumn(table: "dbo.ExperimentProgramme", name: "Name", newName: "ProgrammeName");            
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.ExperimentProgramme", name: "ProgrammeName", newName: "Name");
            RenameIndex(table: "dbo.ExperimentProgramme", name: "IX_ProgrammeImpactMetricModelId", newName: "IX_ImpactMetricModelId");
            RenameIndex(table: "dbo.ExperimentProgramme", name: "IX_ProgrammeTargetMetricModelId", newName: "IX_TargetMetricModelId");
            RenameColumn(table: "dbo.ExperimentProgramme", name: "ProgrammeTargetMetricModelId", newName: "TargetMetricModelId");
            RenameColumn(table: "dbo.ExperimentProgramme", name: "ProgrammeImpactMetricModelId", newName: "ImpactMetricModelId");
        }
    }
}
