using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class NumberLesson
    {
        public int NumberLessonId { get; set; }
        public DateTime? StartLessonDate { get; set; }
        public DateTime? EndLessonDate { get; set; }
    }
}
