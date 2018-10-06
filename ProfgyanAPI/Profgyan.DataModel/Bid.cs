namespace Profgyan.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        public string BidId { get; set; }
        public bool FixedRate { get; set; }
        public bool FinalBid { get; set; }
        //Foreign key
        public string CourseId { get; set; }
        public string TrainerId { get; set; }
        
        public Trainer Trainer { get; set; }
        public Trainee Trainee { get; set; }
    }
}
