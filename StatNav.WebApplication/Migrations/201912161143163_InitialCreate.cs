namespace StatNav.WebApplication.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExperimentIteration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExperimentProgrammeId = c.Int(nullable: false),
                        RequiredDurationForSignificance = c.String(),
                        IterationNumber = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExperimentProgramme", t => t.ExperimentProgrammeId, cascadeDelete: true)
                .Index(t => t.ExperimentProgrammeId);
            
            CreateTable(
                "dbo.ExperimentProgramme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Problem = c.String(),
                        ExperimentStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExperimentStatus", t => t.ExperimentStatusId, cascadeDelete: true)
                .Index(t => t.ExperimentStatusId);
            
            CreateTable(
                "dbo.ExperimentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExperimentIteration", "ExperimentProgrammeId", "dbo.ExperimentProgramme");
            DropForeignKey("dbo.ExperimentProgramme", "ExperimentStatusId", "dbo.ExperimentStatus");
            DropIndex("dbo.ExperimentProgramme", new[] { "ExperimentStatusId" });
            DropIndex("dbo.ExperimentIteration", new[] { "ExperimentProgrammeId" });
            DropTable("dbo.ExperimentStatus");
            DropTable("dbo.ExperimentProgramme");
            DropTable("dbo.ExperimentIteration");
        }
    }
}
