using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DTO
{
    public partial class TrainerPersonalDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainerPersonalDTO()
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
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string dob { get; set; }
        [StringLength(50)]
        [Required]
        public string state { get; set; }
        [StringLength(50)]
        [Required]
        public string City { get; set; }
        [StringLength(50)]
        [Required]
        public string PINCode { get; set; }
        [StringLength(200)]
        public string address { get; set; }
        public string CommonDetailID { get; set; }
        public string TrainerId { get; set; }

    }
}
