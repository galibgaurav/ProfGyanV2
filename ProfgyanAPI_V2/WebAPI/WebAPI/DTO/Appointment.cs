

namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public string AppointmentId { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string TraineeID { get; set; }
        public string TrainerId { get; set; }
    
        public virtual Trainee Trainee { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
