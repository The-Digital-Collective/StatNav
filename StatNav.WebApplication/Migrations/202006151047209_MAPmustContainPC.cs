namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAPmustContainPC : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MarketingAssetPackage", new[] { "PackageContainerId" });
            AlterColumn("dbo.MarketingAssetPackage", "PackageContainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.MarketingAssetPackage", "PackageContainerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MarketingAssetPackage", new[] { "PackageContainerId" });
            AlterColumn("dbo.MarketingAssetPackage", "PackageContainerId", c => c.Int());
            CreateIndex("dbo.MarketingAssetPackage", "PackageContainerId");
        }
    }
}
