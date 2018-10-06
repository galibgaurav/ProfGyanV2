using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DTO
{
    public partial class SessionTrainee_MapDTO
    {
        [StringLength(128)]
        public string SessionTrainee_MapID { get; set; }
        //foreign key
        public string SessionId { get; set; }

        //navigation key

        public SessionDTO Session { get; set; }

        //foreign key
        public string TraineeId { get; set; }

        //navigation key

        public TraineeDTO Trainee { get; set; }
    }
}
