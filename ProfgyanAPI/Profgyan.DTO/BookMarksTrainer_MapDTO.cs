using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DTO
{
    public partial class BookMarksTrainer_MapDTO
    {
        [StringLength(128)]
        public string BookMarksTrainer_MapID { get; set; }
        [StringLength(128)]
        public string BookmarkId { get; set; }
        [StringLength(128)]
        public string TraineeId { get; set; }
    }
}
