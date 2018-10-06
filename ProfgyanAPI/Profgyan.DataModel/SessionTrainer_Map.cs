using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DataModel
{
    public partial class SessionTrainer_Map
    {
        [StringLength(128)]
        public string SessionTrainer_MapID { get; set; }
        //foreign key
        public string SessionId { get; set; }

        //navigation key

        public Session Session { get; set; }

        //foreign key
        public string TrainerId { get; set; }

        //navigation key

        public Trainer Trainer{ get; set; }
    }
}
