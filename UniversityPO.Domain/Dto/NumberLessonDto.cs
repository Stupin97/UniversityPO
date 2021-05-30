namespace UniversityPO.Domain.Dto
{
    using System;

    public class NumberLessonDto
    {
        public int NumberLessonId { get; set; }
        public DateTime? StartLessonDate { get; set; }
        public DateTime? EndLessonDate { get; set; }
    }
}
