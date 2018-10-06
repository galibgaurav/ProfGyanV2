namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TraineeDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TraineeDTO()
        {
           // CommonDetails = new HashSet<CommonDetail>();
        }

        [StringLength(128)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public string TraineeID { get; set; }

        public string AreaOfIntrest { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        //Foreign key 
        public string CommonDetailID { get; set; } 
        //Navigation properties
        public virtual CommonDetailDTO CommonDetail { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CommonDetail> CommonDetails { get; set; }


    }
}
