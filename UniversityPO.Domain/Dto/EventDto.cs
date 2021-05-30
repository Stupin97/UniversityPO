namespace UniversityPO.Domain.Dto
{
    using System;

    public class EventDto
    {
        public int EventId { get; set; }
        public string Text { get; set; }
        public DateTime? DatePublic { get; set; }
        public bool? IsUrgently { get; set; }
        //public bool? IsHidden { get; set; }
        public bool? IsImportant { get; set; }
    }
}
