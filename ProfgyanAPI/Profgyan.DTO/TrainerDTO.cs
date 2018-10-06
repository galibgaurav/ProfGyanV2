namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TrainerDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainerDTO()
        {
            //CommonDetails = new HashSet<CommonDetail>();
        }
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+")]
        public string email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(11)]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string highestQualification { get; set; }

        [StringLength(50)]
        [Required]
        public string department { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        [RegularExpression("^[0-9]*$")]
        public string academicYear { get; set; }

        public string dob { get; set; }
        [Required]
        public string industrialExp { get; set; }

        [StringLength(100)]
        public string companies { get; set; }
        [Required]
        public string teachingExp { get; set; }
        [StringLength(300)]
        public string socialMediaLink { get; set; }

        [StringLength(200)]
        public string address { get; set; }
        [StringLength(300)]
        public string skillSet { get; set; }

        [StringLength(50)]
        public string state { get; set; }
        [StringLength(50)]

        public string City { get; set; }
        [StringLength(50)]

        public string PINCode { get; set; }
        //public object avatar { get; set; }

    }
}
