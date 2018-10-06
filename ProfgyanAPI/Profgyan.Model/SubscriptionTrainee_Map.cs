﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.Model
{
    public class SubscriptionTrainee_Map
    {
        [Required]
        public string SubscriptionId { get; set; }
        [Required]
        public string TraineeId { get; set; }
    }
}
