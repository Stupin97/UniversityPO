namespace UniversityPO.Domain.Dto
{
    using System;
    using System.Collections.Generic;

    using UniversityPO.Domain.Models;
    public class AcademicPerfomanceDto
    {
        public int AcademicPerfomanceId { get; set; }
        public string StudentId { get; set; }
        public string GroupName { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int? Semester { get; set; }
        public int? DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public int? Rating { get; set; }
        public DateTime? DateReceiptRating { get; set; }
        public int? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }

        //public Discipline Discipline { get; set; }
        //public Student Student { get; set; }
        //public Teacher Teacher { get; set; }
    }
}
