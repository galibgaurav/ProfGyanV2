namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class CourseDTO
    {
        public string CourseId { get; set; }

        [StringLength(50)]
        public string CourseName { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [StringLength(128)]
        public string StatusId { get; set; }

        public string URL { get; set; }
    }
}
