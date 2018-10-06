namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class BidDTO
    {
        public string BidId { get; set; }
        public bool FixedRate { get; set; }
        public bool FinalBid { get; set; }
        //Foreign key
        public string CourseId { get; set; }
        public string TrainerId { get; set; }
        
        public TrainerDTO Trainer { get; set; }
        public TraineeDTO Trainee { get; set; }
    }
}
