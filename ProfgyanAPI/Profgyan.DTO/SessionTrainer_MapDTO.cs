using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DTO
{
    public partial class SessionTrainer_MapDTO
    {
        [StringLength(128)]
        public string SessionTrainer_MapID { get; set; }
        //foreign key
        public string SessionId { get; set; }

        //navigation key

        public SessionDTO Session { get; set; }

        //foreign key
        public string TrainerId { get; set; }

        //navigation key

        public TrainerDTO Trainer{ get; set; }
    }
}
