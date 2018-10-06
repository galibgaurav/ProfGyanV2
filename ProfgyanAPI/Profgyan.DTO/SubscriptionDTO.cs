namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubscriptionDTO
    {
        public string SubscriptionId { get; set; }

        [StringLength(128)]
        public string CourseId { get; set; }

        [StringLength(300)]
        public string Comments { get; set; }
    }
}
