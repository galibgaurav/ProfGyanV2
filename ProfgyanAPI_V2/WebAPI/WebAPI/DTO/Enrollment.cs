namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enrollment
    {
        public string EnrollmentId { get; set; }
        public string TrainerId { get; set; }
        public Nullable<System.DateTime> DateEnrolled { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string CourseID { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
