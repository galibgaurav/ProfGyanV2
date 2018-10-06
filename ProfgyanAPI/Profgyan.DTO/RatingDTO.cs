namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

     public partial class RatingDTO
    {
        public string RatingId { get; set; }

        public int? StarsCount { get; set; }
    }
}
