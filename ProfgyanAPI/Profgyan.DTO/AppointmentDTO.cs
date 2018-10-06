namespace Profgyan.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class AppointmentDTO
    {
        
        public string AppointmentId { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(300)]
        public string Message { get; set; }

        //Foreign key
        public string TraineeID { get; set; }
        public string TrainerId { get; set; }
        //Navigation Property
        public TraineeDTO Trainee { get; set; }
        public TrainerDTO Trainer { get; set; }
    }
}
