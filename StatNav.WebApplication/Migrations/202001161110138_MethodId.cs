namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MethodId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MarketingAssetPackage", name: "Method", newName: "MethodId");
            RenameIndex(table: "dbo.MarketingAssetPackage", name: "IX_Method", newName: "IX_MethodId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MarketingAssetPackage", name: "IX_MethodId", newName: "IX_Method");
            RenameColumn(table: "dbo.MarketingAssetPackage", name: "MethodId", newName: "Method");
        }
    }
}
