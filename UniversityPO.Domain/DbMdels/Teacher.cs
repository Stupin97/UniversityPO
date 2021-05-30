using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Teacher
    {
        //public Teacher()
        //{
        //    AcademicPerfomance = new HashSet<AcademicPerfomance>();
        //}

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? DisciplineId { get; set; }
        public int? PositionId { get; set; }
        public int? AcademicDegreeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public /*virtual*/ AcademicDegree AcademicDegree { get; set; }
        public /*virtual*/ Discipline Discipline { get; set; }
        public /*virtual*/ Position Position { get; set; }
        public /*virtual*/ List<AcademicPerfomance> AcademicPerfomance { get; set; }
    }
}
