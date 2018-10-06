namespace Profgyan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        BidId = c.String(nullable: false, maxLength: 128),
                        FixedRate = c.Boolean(nullable: false),
                        FinalBid = c.Boolean(nullable: false),
                        CourseId = c.String(),
                        TrainerId = c.String(maxLength: 128),
                        Trainee_TraineeID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BidId)
                .ForeignKey("dbo.Trainee", t => t.Trainee_TraineeID)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.TrainerId)
                .Index(t => t.Trainee_TraineeID);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactusId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bid", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Bid", "Trainee_TraineeID", "dbo.Trainee");
            DropIndex("dbo.Bid", new[] { "Trainee_TraineeID" });
            DropIndex("dbo.Bid", new[] { "TrainerId" });
            DropTable("dbo.ContactUs");
            DropTable("dbo.Bid");
        }
    }
}
