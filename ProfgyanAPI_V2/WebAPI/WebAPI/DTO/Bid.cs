namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bid
    {
        public string BidId { get; set; }
        public bool FixedRate { get; set; }
        public bool FinalBid { get; set; }
        public string CourseId { get; set; }
        public string TrainerId { get; set; }
        public string Trainee_TraineeID { get; set; }
    
        public virtual Trainee Trainee { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
