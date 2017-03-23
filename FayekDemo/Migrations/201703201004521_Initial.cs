namespace FayekDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        AssignmentName = c.String(),
                        ClientName = c.String(),
                        Percentage = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        ConsultantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Consultant", t => t.ConsultantId, cascadeDelete: true)
                .Index(t => t.ConsultantId);
            
            CreateTable(
                "dbo.Consultant",
                c => new
                    {
                        ConsultantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ConsultantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment", "ConsultantId", "dbo.Consultant");
            DropIndex("dbo.Assignment", new[] { "ConsultantId" });
            DropTable("dbo.Consultant");
            DropTable("dbo.Assignment");
        }
    }
}
