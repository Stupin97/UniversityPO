using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class AcademicPerfomance
    {
        public int AcademicPerfomanceId { get; set; }
        public string StudentId { get; set; }
        public int? Semester { get; set; }
        public int? DisciplineId { get; set; }
        public int? Rating { get; set; }
        public DateTime? DateReceiptRating { get; set; }
        public int? TeacherId { get; set; }

        public /*virtual*/ Discipline Discipline { get; set; }
        public /*virtual*/ Student Student { get; set; }
        public /*virtual*/ Teacher Teacher { get; set; }
    }
}
