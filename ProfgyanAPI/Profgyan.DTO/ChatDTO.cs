namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class ChatDTO
    {
        public string ChatID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Comments { get; set; }
    }
}
