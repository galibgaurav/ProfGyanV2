namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class SocialMedia
    {
        public string SocialMediaId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string TrDetailId { get; set; }
    
        public virtual User User { get; set; }
    }
}
