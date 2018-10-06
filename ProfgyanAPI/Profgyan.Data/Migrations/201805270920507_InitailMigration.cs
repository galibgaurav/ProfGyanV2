namespace Profgyan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommonDetails", "ComDetailId", "dbo.Trainee");
            DropForeignKey("dbo.CommonDetails", "ComDetailId", "dbo.Trainers");
            DropIndex("dbo.CommonDetails", new[] { "ComDetailId" });
            AddColumn("dbo.Trainee", "CommonDetailID", c => c.String(maxLength: 128));
            AddColumn("dbo.Trainers", "CommonDetailID", c => c.String(maxLength: 128));
            AddColumn("dbo.SocialMedia", "TrDetailId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Appointment", "TraineeID");
            CreateIndex("dbo.Appointment", "TrainerId");
            CreateIndex("dbo.Trainee", "CommonDetailID");
            CreateIndex("dbo.Trainers", "CommonDetailID");
            CreateIndex("dbo.Enrollment", "CourseID");
            CreateIndex("dbo.SocialMedia", "TrDetailId");
            CreateIndex("dbo.TrainerDetails", "TrainerId");
            AddForeignKey("dbo.Trainee", "CommonDetailID", "dbo.CommonDetails", "ID");
            AddForeignKey("dbo.Appointment", "TraineeID", "dbo.Trainee", "TraineeID");
            AddForeignKey("dbo.Trainers", "CommonDetailID", "dbo.CommonDetails", "ID");
            AddForeignKey("dbo.Appointment", "TrainerId", "dbo.Trainers", "TrainerId");
            AddForeignKey("dbo.Enrollment", "CourseID", "dbo.Course", "CourseId");
            AddForeignKey("dbo.TrainerDetails", "TrainerId", "dbo.Trainers", "TrainerId");
            AddForeignKey("dbo.SocialMedia", "TrDetailId", "dbo.TrainerDetails", "TrDetailId");
            DropColumn("dbo.Trainee", "ComDetailId");
            DropColumn("dbo.Trainers", "ComDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "ComDetailId", c => c.String(maxLength: 128));
            AddColumn("dbo.Trainee", "ComDetailId", c => c.String(maxLength: 50));
            DropForeignKey("dbo.SocialMedia", "TrDetailId", "dbo.TrainerDetails");
            DropForeignKey("dbo.TrainerDetails", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Appointment", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "CommonDetailID", "dbo.CommonDetails");
            DropForeignKey("dbo.Appointment", "TraineeID", "dbo.Trainee");
            DropForeignKey("dbo.Trainee", "CommonDetailID", "dbo.CommonDetails");
            DropIndex("dbo.TrainerDetails", new[] { "TrainerId" });
            DropIndex("dbo.SocialMedia", new[] { "TrDetailId" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Trainers", new[] { "CommonDetailID" });
            DropIndex("dbo.Trainee", new[] { "CommonDetailID" });
            DropIndex("dbo.Appointment", new[] { "TrainerId" });
            DropIndex("dbo.Appointment", new[] { "TraineeID" });
            DropColumn("dbo.SocialMedia", "TrDetailId");
            DropColumn("dbo.Trainers", "CommonDetailID");
            DropColumn("dbo.Trainee", "CommonDetailID");
            CreateIndex("dbo.CommonDetails", "ComDetailId");
            AddForeignKey("dbo.CommonDetails", "ComDetailId", "dbo.Trainers", "TrainerId");
            AddForeignKey("dbo.CommonDetails", "ComDetailId", "dbo.Trainee", "TraineeID");
        }
    }
}
