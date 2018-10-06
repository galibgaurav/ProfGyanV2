using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Profgyan.DTO
{
    public partial class SubscriptionTrainee_MapDTO
    {
        [StringLength(128)]
        public string SubscriptionTrainee_MapID { get; set; }
        //Foreign key
        public string SubscriptionId { get; set; }
        //Navigation property
        public SubscriptionDTO Subscription { get; set; }

        [StringLength(128)]
        public string TraineeId { get; set; }
    }
}
