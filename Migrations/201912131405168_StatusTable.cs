namespace StatNav.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status_Name = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Programme", "StatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Programme", "StatusID");
            AddForeignKey("dbo.Programme", "StatusID", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programme", "StatusID", "dbo.Status");
            DropIndex("dbo.Programme", new[] { "StatusID" });
            DropColumn("dbo.Programme", "StatusID");
            DropTable("dbo.Status");
        }
    }
}
