namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
