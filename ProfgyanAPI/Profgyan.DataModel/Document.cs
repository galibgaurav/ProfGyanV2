namespace Profgyan.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Document
    {
        public string DocumentId { get; set; }

        private string Filepath { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }
        [StringLength(50)]
        public string FileType { get; set; }

        [StringLength(50)]
        public string UserIdentity { get; set; }

    }
}
