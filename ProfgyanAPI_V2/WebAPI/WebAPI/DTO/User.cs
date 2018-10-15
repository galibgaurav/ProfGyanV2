namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.UserLogins = new HashSet<UserLogin>();
            this.Roles = new HashSet<Role>();
            this.UserClaims = new HashSet<UserClaim>();
        }
    
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }
        public string SocialMediaId { get; set; }
    
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
    }
}
