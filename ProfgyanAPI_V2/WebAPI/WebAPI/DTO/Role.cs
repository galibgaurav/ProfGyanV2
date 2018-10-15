namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
