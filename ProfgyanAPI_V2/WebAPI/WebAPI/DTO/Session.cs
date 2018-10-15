namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Session
    {
        public string SessionId { get; set; }
        public Nullable<System.DateTime> Timing { get; set; }
        public string CourseId { get; set; }
    }
}
