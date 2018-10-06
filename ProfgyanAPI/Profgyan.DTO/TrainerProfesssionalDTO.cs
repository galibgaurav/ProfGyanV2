using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DTO
{
    public partial class TrainerProfesssionalDTO
    {
        public TrainerProfesssionalDTO()
        {
            //CommonDetails = new HashSet<CommonDetail>();
        }
        [Required]
        [StringLength(50)]
        public string highestQualification { get; set; }

        [Required]
        [StringLength(50)]
        public string department { get; set; }

        public string academicYear { get; set; }
        
        public string industrialExp { get; set; }
        [StringLength(300)]
        public string skillSet { get; set; }
      
        public string teachingExp { get; set; }
       
        public string socialMediaLink { get; set; }

        public string CommonDetailID { get; set; }
        public string TrainerId { get; set; }
        public string TrainerDetailID { get; set; }
    }
}
