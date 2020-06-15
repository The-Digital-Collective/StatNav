namespace StatNav.WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2069RemoveAttributesFromMAPEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MarketingAssetPackage", "ExperimentStatusId", "dbo.ExperimentStatus");
            DropForeignKey("dbo.MarketingAssetPackage", "MAPImpactMetricModelId", "dbo.MetricModel");
            DropForeignKey("dbo.MarketingAssetPackage", "MethodId", "dbo.Method");
            DropForeignKey("dbo.MarketingAssetPackage", "MAPTargetMetricModelId", "dbo.MetricModel");
            DropIndex("dbo.MarketingAssetPackage", new[] { "MethodId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MAPTargetMetricModelId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "MAPImpactMetricModelId" });
            DropIndex("dbo.MarketingAssetPackage", new[] { "ExperimentStatusId" });
            DropColumn("dbo.MarketingAssetPackage", "MethodId");
            DropColumn("dbo.MarketingAssetPackage", "MAPTargetMetricModelId");
            DropColumn("dbo.MarketingAssetPackage", "TargetValue");
            DropColumn("dbo.MarketingAssetPackage", "MAPImpactMetricModelId");
            DropColumn("dbo.MarketingAssetPackage", "ImpactValue");
            DropColumn("dbo.MarketingAssetPackage", "ExperimentStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MarketingAssetPackage", "ExperimentStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.MarketingAssetPackage", "ImpactValue", c => c.Single(nullable: false));
            AddColumn("dbo.MarketingAssetPackage", "MAPImpactMetricModelId", c => c.Int(nullable: false));
            AddColumn("dbo.MarketingAssetPackage", "TargetValue", c => c.Single(nullable: false));
            AddColumn("dbo.MarketingAssetPackage", "MAPTargetMetricModelId", c => c.Int(nullable: false));
            AddColumn("dbo.MarketingAssetPackage", "MethodId", c => c.Int(nullable: false));
            CreateIndex("dbo.MarketingAssetPackage", "ExperimentStatusId");
            CreateIndex("dbo.MarketingAssetPackage", "MAPImpactMetricModelId");
            CreateIndex("dbo.MarketingAssetPackage", "MAPTargetMetricModelId");
            CreateIndex("dbo.MarketingAssetPackage", "MethodId");
            AddForeignKey("dbo.MarketingAssetPackage", "MAPTargetMetricModelId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.MarketingAssetPackage", "MethodId", "dbo.Method", "Id");
            AddForeignKey("dbo.MarketingAssetPackage", "MAPImpactMetricModelId", "dbo.MetricModel", "Id");
            AddForeignKey("dbo.MarketingAssetPackage", "ExperimentStatusId", "dbo.ExperimentStatus", "Id");
        }
    }
}
