
namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class CommonDetail
    {
        public CommonDetail()
        {
            this.Trainees = new HashSet<Trainee>();
            this.Trainers = new HashSet<Trainer>();
        }
    
        public string ID { get; set; }
        public string state { get; set; }
        public string City { get; set; }
        public string PINCode { get; set; }
        public Nullable<System.DateTime> AcademicYear { get; set; }
        public string HighestQualification { get; set; }
        public string Department { get; set; }
        public string Grade { get; set; }
        public byte[] Photo { get; set; }
    
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
