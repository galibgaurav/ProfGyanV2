namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   public partial class SubscriptionTrainer_MapDTO
    {
        [StringLength(128)]
        public string SubscriptionTrainer_MapID { get; set; }
        //Foreign key
        public string SubscriptionId { get; set; }
        //Navigation property
        public SubscriptionDTO Subscription { get; set; }

        [StringLength(128)]
        public string TrainerId { get; set; }
    }
}
