namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2067StagesTableEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MetricModelStage", "MarketingModelId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MetricModelStage", "MarketingModelId");
        }
    }
}
