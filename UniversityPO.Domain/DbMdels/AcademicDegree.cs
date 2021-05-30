using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class AcademicDegree
    {
        //public AcademicDegree()
        //{
        //    Teacher = new HashSet<Teacher>();
        //}

        public int AcademicDegreeId { get; set; }
        public string Name { get; set; }

        public List<Teacher> Teacher { get; set; }
    }
}
