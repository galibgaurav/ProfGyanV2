namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class ValidationPasscode
    {
        public string validationElement { get; set; }
        public string passcode { get; set; }
        public Nullable<System.DateTime> createdTime { get; set; }
        public Nullable<System.DateTime> expiryTime { get; set; }
    }
}
