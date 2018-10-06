using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Profgyan.DataModel
{
    [Table("SubscriptionTrainee_Map")]
    public partial class SubscriptionTrainee_Map
    {
        [StringLength(128)]
        public string SubscriptionTrainee_MapID { get; set; }
        //Foreign key
        public string SubscriptionId { get; set; }
        //Navigation property
        public Subscription Subscription { get; set; }

        [StringLength(128)]
        public string TraineeId { get; set; }
    }
}
