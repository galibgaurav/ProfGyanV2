using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DTO
{
    public partial class BookMarksTrainee_MapDTO
    {
        [Key]
        public string BookmarkId { get; set; }
        [StringLength(128)]
        public string TraineeId { get; set; }
    }
}
