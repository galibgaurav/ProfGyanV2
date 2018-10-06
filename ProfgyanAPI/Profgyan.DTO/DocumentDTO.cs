namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DocumentDTO
    {
        public string DocumentId { get; set; }

        [StringLength(200)]
        public string Filepath { get; set; }

        [StringLength(50)]
        public string Foldername { get; set; }
    }
}
