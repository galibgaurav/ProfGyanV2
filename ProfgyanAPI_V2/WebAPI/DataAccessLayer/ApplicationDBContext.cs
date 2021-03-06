﻿namespace DataAccessLayer
{
    using BusinessDataModel;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public partial class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext()
            : base("Data Source=A2ML29388\\SQLSERVER;Initial Catalog=Practice;Persist Security Info=True;User ID=sa;password=Password1;MultipleActiveResultSets=True;App=EntityFramework", throwIfV1Schema: false)
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public static ApplicationDBContext Create()
        {
            return new ApplicationDBContext();
        }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<BookMark> BookMarks { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<CommonDetail> CommonDetails { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<PaymentMode> PaymentModes { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SocialMedia> SocialMedias { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<TrainerDetail> TrainerDetails { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainingType> TrainingTypes { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<UserClaim> UserClaims { get; set; }
        //public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<ValidationPasscode> ValidationPasscodes { get; set; }
    }
}
