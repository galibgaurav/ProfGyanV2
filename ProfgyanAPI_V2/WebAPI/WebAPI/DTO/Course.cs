namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public Course()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }
    
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public string StatusId { get; set; }
        public string URL { get; set; }
    
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
