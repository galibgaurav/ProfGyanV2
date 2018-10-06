namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookMarkDTO
    {
        public string BookmarkId { get; set; }

        [StringLength(128)]
        public string CourseId { get; set; }
    }
}
