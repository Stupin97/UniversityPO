using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Discipline
    {
        //public Discipline()
        //{
        //    AcademicPerfomance = new HashSet<AcademicPerfomance>();
        //    Teacher = new HashSet<Teacher>();
        //}

        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public int? DeliveryTypeId { get; set; }
        public int? TotalHours { get; set; }

        public /*virtual*/ DeliveryType DeliveryType { get; set; }
        public /*virtual*/ List<AcademicPerfomance> AcademicPerfomance { get; set; }
        public /*virtual*/ List<Teacher> Teacher { get; set; }
    }
}
