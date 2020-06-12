namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2085NewTablePackageContainer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackageContainer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageContainerName = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        MetricModelStageId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MetricModelStage", t => t.MetricModelStageId)
                .Index(t => t.MetricModelStageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageContainer", "MetricModelStageId", "dbo.MetricModelStage");
            DropIndex("dbo.PackageContainer", new[] { "MetricModelStageId" });
            DropTable("dbo.PackageContainer");
        }
    }
}
