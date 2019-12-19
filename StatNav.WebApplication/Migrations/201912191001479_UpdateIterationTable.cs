namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIterationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExperimentIteration", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ExperimentProgramme", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExperimentProgramme", "Name", c => c.String());
            DropColumn("dbo.ExperimentIteration", "Name");
        }
    }
}
