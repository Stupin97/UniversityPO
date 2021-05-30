using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Text { get; set; }
        public DateTime? DatePublic { get; set; }
        public bool? IsUrgently { get; set; }
        public bool? IsHidden { get; set; }
        public bool? IsImportant { get; set; }
    }
}
