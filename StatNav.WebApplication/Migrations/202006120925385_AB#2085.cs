namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AB2085 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketingAssetPackage", "PackageContainerId", c => c.Int());
            CreateIndex("dbo.MarketingAssetPackage", "PackageContainerId");
            AddForeignKey("dbo.MarketingAssetPackage", "PackageContainerId", "dbo.PackageContainer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarketingAssetPackage", "PackageContainerId", "dbo.PackageContainer");
            DropIndex("dbo.MarketingAssetPackage", new[] { "PackageContainerId" });
            DropColumn("dbo.MarketingAssetPackage", "PackageContainerId");
        }
    }
}
