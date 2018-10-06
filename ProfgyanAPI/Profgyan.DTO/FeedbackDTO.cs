namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FeedbackDTO
    {
        public string FeedbackId { get; set; }

        public string Comments { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }
    }
}
