namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trainer
    {
        public Trainer()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Bids = new HashSet<Bid>();
            this.TrainerDetails = new HashSet<TrainerDetail>();
        }
    
        public string TrainerId { get; set; }
        public string UserID { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string RatingId { get; set; }
        public string StatusId { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public string CommonDetailID { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual CommonDetail CommonDetail { get; set; }
        public virtual ICollection<TrainerDetail> TrainerDetails { get; set; }
    }
}
