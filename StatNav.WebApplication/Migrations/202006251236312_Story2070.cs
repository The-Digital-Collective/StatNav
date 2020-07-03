namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Story2070 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ExperimentIteration", newName: "Experiment");
            RenameColumn(table: "dbo.ExperimentCandidate", name: "ExperimentIterationId", newName: "ExperimentId");
            RenameIndex(table: "dbo.ExperimentCandidate", name: "IX_ExperimentIterationId", newName: "IX_ExperimentId");
            AddColumn("dbo.Experiment", "ExperimentName", c => c.String(nullable: false));
            AddColumn("dbo.Experiment", "ExperimentNumber", c => c.Int());
            AlterColumn("dbo.Experiment", "StartDateTime", c => c.DateTime());
            AlterColumn("dbo.Experiment", "EndDateTime", c => c.DateTime());
            DropColumn("dbo.Experiment", "IterationName");
            DropColumn("dbo.Experiment", "IterationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiment", "IterationNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Experiment", "IterationName", c => c.String(nullable: false));
            AlterColumn("dbo.Experiment", "EndDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experiment", "StartDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Experiment", "ExperimentNumber");
            DropColumn("dbo.Experiment", "ExperimentName");
            RenameIndex(table: "dbo.ExperimentCandidate", name: "IX_ExperimentId", newName: "IX_ExperimentIterationId");
            RenameColumn(table: "dbo.ExperimentCandidate", name: "ExperimentId", newName: "ExperimentIterationId");
            RenameTable(name: "dbo.Experiment", newName: "ExperimentIteration");
        }
    }
}
