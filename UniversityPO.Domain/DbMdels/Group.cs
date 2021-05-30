using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Group
    {
        //public Group()
        //{
        //    Student = new HashSet<Student>();
        //}

        public string GroupId { get; set; }
        public int? FacultyId { get; set; }
        public int? SpecialtyId { get; set; }
        public int? Course { get; set; }
        public DateTime? DateReceipt { get; set; }

        public /*virtual*/ Faculty Faculty { get; set; }
        public /*virtual*/ Specialty Specialty { get; set; }
        public /*virtual*/ List<Student> Student { get; set; }
    }
}
