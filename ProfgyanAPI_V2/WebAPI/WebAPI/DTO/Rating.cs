namespace DataModelDTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rating
    {
        public string RatingId { get; set; }
        public Nullable<int> StarsCount { get; set; }
    }
}
