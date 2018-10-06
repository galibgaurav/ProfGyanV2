namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentModeDTO
    {
        [Key]
        public string ModeId { get; set; }

        [StringLength(20)]
        public string Mode { get; set; }

        [StringLength(128)]
        public string StatusId { get; set; }
    }
}
