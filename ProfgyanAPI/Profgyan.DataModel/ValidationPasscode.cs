using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profgyan.DataModel
{
    public partial class ValidationPasscode
    {
        [Key]
        public string validationElement { get; set; }// Example: email  or phone or mobule number or adhar card
        public string passcode { get; set; }
        public DateTime? createdTime { get; set; }
        public DateTime? expiryTime { get; set; }

    }
}
