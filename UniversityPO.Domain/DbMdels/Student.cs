using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Student
    {
        //public Student()
        //{
        //    AcademicPerfomance = new HashSet<AcademicPerfomance>();
        //}

        public string StudentId { get; set; }
        public string GroupId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool? IsHeadman { get; set; }

        public /*virtual*/ Group Group { get; set; }
        public /*virtual*/ List<AcademicPerfomance> AcademicPerfomance { get; set; }
    }
}
