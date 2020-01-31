namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MethodId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ExperimentProgramme", name: "Method", newName: "MethodId");
            RenameIndex(table: "dbo.ExperimentProgramme", name: "IX_Method", newName: "IX_MethodId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ExperimentProgramme", name: "IX_MethodId", newName: "IX_Method");
            RenameColumn(table: "dbo.ExperimentProgramme", name: "MethodId", newName: "Method");
        }
    }
}
