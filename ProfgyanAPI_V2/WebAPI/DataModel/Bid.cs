//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
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