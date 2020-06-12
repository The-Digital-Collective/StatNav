namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AB2085 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExperimentProgramme", "PackageContainerId", c => c.Int());
            CreateIndex("dbo.ExperimentProgramme", "PackageContainerId");
            AddForeignKey("dbo.ExperimentProgramme", "PackageContainerId", "dbo.PackageContainer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExperimentProgramme", "PackageContainerId", "dbo.PackageContainer");
            DropIndex("dbo.ExperimentProgramme", new[] { "PackageContainerId" });
            DropColumn("dbo.ExperimentProgramme", "PackageContainerId");
        }
    }
}
