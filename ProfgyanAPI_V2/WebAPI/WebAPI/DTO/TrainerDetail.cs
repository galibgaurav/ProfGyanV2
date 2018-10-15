namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrainerDetail
    {
        public string TrDetailId { get; set; }
        public string Experience { get; set; }
        public string Companies { get; set; }
        public string SkillSet { get; set; }
        public string TeachingExperience { get; set; }
        public string Rewards { get; set; }
        public string TeachingReason { get; set; }
        public string TrainerId { get; set; }
    
        public virtual Trainer Trainer { get; set; }
    }
}
