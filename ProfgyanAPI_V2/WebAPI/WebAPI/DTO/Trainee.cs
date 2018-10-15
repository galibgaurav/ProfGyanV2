namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trainee
    {
        public Trainee()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Bids = new HashSet<Bid>();
        }
    
        public string TraineeID { get; set; }
        public string UserID { get; set; }
        public string AreaOfIntrest { get; set; }
        public string StatusId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CommonDetailID { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual CommonDetail CommonDetail { get; set; }
    }
}
