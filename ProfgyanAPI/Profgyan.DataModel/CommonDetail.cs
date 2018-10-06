namespace Profgyan.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommonDetail
    {
        public string ID { get; set; }

        //[StringLength(128)]
        //public string ComDetailId { get; set; }

        [StringLength(200)]
        [Required]
        public string Address { get; set; }
       
        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]
       
        public string City { get; set; }
        [StringLength(50)]
        
        public string PINCode { get; set; }
        public DateTime? AcademicYear { get; set; }

        [Required]
        public DateTime? DOB { get; set; }

        //[Required]
        [StringLength(50)]
        public string HighestQualification{ get; set; }

        //[Required]
        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string Grade { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        
    }
}
