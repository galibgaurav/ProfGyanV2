namespace Profgyan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubscriptionMap : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SubscriptionTrainer_Map");
            CreateTable(
                "dbo.BookMarksTrainee_Map",
                c => new
                    {
                        BookmarkId = c.String(nullable: false, maxLength: 128),
                        TraineeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookmarkId);
            
            CreateTable(
                "dbo.BookMarksTrainer_Map",
                c => new
                    {
                        BookMarksTrainer_MapID = c.String(nullable: false, maxLength: 128),
                        BookmarkId = c.String(maxLength: 128),
                        TraineeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookMarksTrainer_MapID);
            
            CreateTable(
                "dbo.SessionTrainee_Map",
                c => new
                    {
                        SessionTrainee_MapID = c.String(nullable: false, maxLength: 128),
                        SessionId = c.String(maxLength: 128),
                        TraineeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SessionTrainee_MapID)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .ForeignKey("dbo.Trainee", t => t.TraineeId)
                .Index(t => t.SessionId)
                .Index(t => t.TraineeId);
            
            CreateTable(
                "dbo.SessionTrainer_Map",
                c => new
                    {
                        SessionTrainer_MapID = c.String(nullable: false, maxLength: 128),
                        SessionId = c.String(maxLength: 128),
                        TrainerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SessionTrainer_MapID)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.SessionId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.SubscriptionTrainee_Map",
                c => new
                    {
                        SubscriptionTrainee_MapID = c.String(nullable: false, maxLength: 128),
                        SubscriptionId = c.String(maxLength: 128),
                        TraineeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SubscriptionTrainee_MapID)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId)
                .Index(t => t.SubscriptionId);
            
            AddColumn("dbo.SubscriptionTrainer_Map", "SubscriptionTrainer_MapID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SubscriptionTrainer_Map", "SubscriptionId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.SubscriptionTrainer_Map", "SubscriptionTrainer_MapID");
            CreateIndex("dbo.SubscriptionTrainer_Map", "SubscriptionId");
            AddForeignKey("dbo.SubscriptionTrainer_Map", "SubscriptionId", "dbo.Subscription", "SubscriptionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubscriptionTrainer_Map", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.SubscriptionTrainee_Map", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.SessionTrainer_Map", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.SessionTrainer_Map", "SessionId", "dbo.Session");
            DropForeignKey("dbo.SessionTrainee_Map", "TraineeId", "dbo.Trainee");
            DropForeignKey("dbo.SessionTrainee_Map", "SessionId", "dbo.Session");
            DropIndex("dbo.SubscriptionTrainer_Map", new[] { "SubscriptionId" });
            DropIndex("dbo.SubscriptionTrainee_Map", new[] { "SubscriptionId" });
            DropIndex("dbo.SessionTrainer_Map", new[] { "TrainerId" });
            DropIndex("dbo.SessionTrainer_Map", new[] { "SessionId" });
            DropIndex("dbo.SessionTrainee_Map", new[] { "TraineeId" });
            DropIndex("dbo.SessionTrainee_Map", new[] { "SessionId" });
            DropPrimaryKey("dbo.SubscriptionTrainer_Map");
            AlterColumn("dbo.SubscriptionTrainer_Map", "SubscriptionId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.SubscriptionTrainer_Map", "SubscriptionTrainer_MapID");
            DropTable("dbo.SubscriptionTrainee_Map");
            DropTable("dbo.SessionTrainer_Map");
            DropTable("dbo.SessionTrainee_Map");
            DropTable("dbo.BookMarksTrainer_Map");
            DropTable("dbo.BookMarksTrainee_Map");
            AddPrimaryKey("dbo.SubscriptionTrainer_Map", "SubscriptionId");
        }
    }
}
