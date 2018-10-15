namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Document
    {
        public string DocumentId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string UserIdentity { get; set; }
    }
}
