namespace Profgyan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        AppointmentId = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(maxLength: 50),
                        Message = c.String(maxLength: 300),
                        TraineeID = c.String(maxLength: 128),
                        TrainerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Trainee", t => t.TraineeID)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.TraineeID)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Trainee",
                c => new
                    {
                        TraineeID = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        AreaOfIntrest = c.String(),
                        StatusId = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        CommonDetailID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TraineeID)
                .ForeignKey("dbo.CommonDetails", t => t.CommonDetailID)
                .Index(t => t.CommonDetailID);
            
            CreateTable(
                "dbo.CommonDetails",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Address = c.String(nullable: false, maxLength: 200),
                        AcademicYear = c.DateTime(),
                        DOB = c.DateTime(nullable: false),
                        HighestQualification = c.String(nullable: false, maxLength: 50),
                        Department = c.String(nullable: false, maxLength: 50),
                        Grade = c.String(maxLength: 50),
                        Photo = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        TypeId = c.Int(),
                        RatingId = c.String(maxLength: 128),
                        StatusId = c.String(maxLength: 128),
                        IsVerified = c.Boolean(),
                        CommonDetailID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrainerId)
                .ForeignKey("dbo.CommonDetails", t => t.CommonDetailID)
                .Index(t => t.CommonDetailID);
            
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        AttendanceId = c.String(nullable: false, maxLength: 128),
                        SessionId = c.String(maxLength: 128),
                        TraineeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AttendanceId);
            
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
                "dbo.BookMarks",
                c => new
                    {
                        BookmarkId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookmarkId);
            
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
                "dbo.Chat",
                c => new
                    {
                        ChatID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 50),
                        Comments = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ChatID);
            
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
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(maxLength: 50),
                        Description = c.String(),
                        Logo = c.Binary(storeType: "image"),
                        StatusId = c.String(maxLength: 128),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.String(nullable: false, maxLength: 128),
                        FileName = c.String(maxLength: 50),
                        FileType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DocumentId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentId = c.String(nullable: false, maxLength: 128),
                        TrainerId = c.String(maxLength: 128),
                        DateEnrolled = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        ModifiedDateTime = c.DateTime(),
                        CourseID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        FeedbackId = c.String(nullable: false, maxLength: 128),
                        Comments = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FeedbackId);
            
            CreateTable(
                "dbo.PaymentModes",
                c => new
                    {
                        ModeId = c.String(nullable: false, maxLength: 128),
                        Mode = c.String(maxLength: 20),
                        StatusId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ModeId);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.String(nullable: false, maxLength: 128),
                        StarsCount = c.Int(),
                    })
                .PrimaryKey(t => t.RatingId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.String(nullable: false, maxLength: 128),
                        Timing = c.DateTime(),
                        CourseId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SessionId);
            
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
                "dbo.SocialMedia",
                c => new
                    {
                        SocialMediaId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 50),
                        Link = c.String(maxLength: 100),
                        TrDetailId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SocialMediaId)
                .ForeignKey("dbo.TrainerDetails", t => t.TrDetailId)
                .Index(t => t.TrDetailId);
            
            CreateTable(
                "dbo.TrainerDetails",
                c => new
                    {
                        TrDetailId = c.String(nullable: false, maxLength: 128),
                        Experience = c.String(nullable: false, maxLength: 300),
                        Companies = c.String(maxLength: 200),
                        SkillSet = c.String(maxLength: 300),
                        TeachingExperience = c.String(nullable: false, maxLength: 300),
                        Rewards = c.String(maxLength: 300),
                        TeachingReason = c.String(maxLength: 300),
                        SocialMediaId = c.String(maxLength: 128),
                        TrainerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrDetailId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.String(nullable: false, maxLength: 128),
                        StatusName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        SubscriptionId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.String(maxLength: 128),
                        Comments = c.String(maxLength: 300, fixedLength: true),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
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
            
            CreateTable(
                "dbo.SubscriptionTrainer_Map",
                c => new
                    {
                        SubscriptionTrainer_MapID = c.String(nullable: false, maxLength: 128),
                        SubscriptionId = c.String(maxLength: 128),
                        TrainerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SubscriptionTrainer_MapID)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TrainingType",
                c => new
                    {
                        TypeId = c.String(nullable: false, maxLength: 128),
                        TypeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.SubscriptionTrainer_Map", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.SubscriptionTrainee_Map", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.SocialMedia", "TrDetailId", "dbo.TrainerDetails");
            DropForeignKey("dbo.TrainerDetails", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.SessionTrainer_Map", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.SessionTrainer_Map", "SessionId", "dbo.Session");
            DropForeignKey("dbo.SessionTrainee_Map", "TraineeId", "dbo.Trainee");
            DropForeignKey("dbo.SessionTrainee_Map", "SessionId", "dbo.Session");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Bid", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Bid", "Trainee_TraineeID", "dbo.Trainee");
            DropForeignKey("dbo.Appointment", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "CommonDetailID", "dbo.CommonDetails");
            DropForeignKey("dbo.Appointment", "TraineeID", "dbo.Trainee");
            DropForeignKey("dbo.Trainee", "CommonDetailID", "dbo.CommonDetails");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.SubscriptionTrainer_Map", new[] { "SubscriptionId" });
            DropIndex("dbo.SubscriptionTrainee_Map", new[] { "SubscriptionId" });
            DropIndex("dbo.TrainerDetails", new[] { "TrainerId" });
            DropIndex("dbo.SocialMedia", new[] { "TrDetailId" });
            DropIndex("dbo.SessionTrainer_Map", new[] { "TrainerId" });
            DropIndex("dbo.SessionTrainer_Map", new[] { "SessionId" });
            DropIndex("dbo.SessionTrainee_Map", new[] { "TraineeId" });
            DropIndex("dbo.SessionTrainee_Map", new[] { "SessionId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.Bid", new[] { "Trainee_TraineeID" });
            DropIndex("dbo.Bid", new[] { "TrainerId" });
            DropIndex("dbo.Trainers", new[] { "CommonDetailID" });
            DropIndex("dbo.Trainee", new[] { "CommonDetailID" });
            DropIndex("dbo.Appointment", new[] { "TrainerId" });
            DropIndex("dbo.Appointment", new[] { "TraineeID" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.TrainingType");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.SubscriptionTrainer_Map");
            DropTable("dbo.SubscriptionTrainee_Map");
            DropTable("dbo.Subscription");
            DropTable("dbo.Status");
            DropTable("dbo.TrainerDetails");
            DropTable("dbo.SocialMedia");
            DropTable("dbo.SessionTrainer_Map");
            DropTable("dbo.SessionTrainee_Map");
            DropTable("dbo.Session");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Rating");
            DropTable("dbo.PaymentModes");
            DropTable("dbo.Feedback");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Documents");
            DropTable("dbo.Course");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Chat");
            DropTable("dbo.BookMarksTrainer_Map");
            DropTable("dbo.BookMarksTrainee_Map");
            DropTable("dbo.BookMarks");
            DropTable("dbo.Bid");
            DropTable("dbo.Attendance");
            DropTable("dbo.Trainers");
            DropTable("dbo.CommonDetails");
            DropTable("dbo.Trainee");
            DropTable("dbo.Appointment");
        }
    }
}
