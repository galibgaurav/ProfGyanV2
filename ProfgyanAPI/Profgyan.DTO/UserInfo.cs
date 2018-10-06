using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DTO
{
    public class UserInfo
    {
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Email { get; set; }

            public string PhoneNumber { get; set; }
            public string Address { get; set; }

            public string State { get; set; }

            public string city { get; set; }
            
            public string[] Roles { get; set; }

            public TrainerDTO trainerDTO { get; set; }
       }
}
