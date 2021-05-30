using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Position
    {
        //public Position()
        //{
        //    Teacher = new HashSet<Teacher>();
        //}

        public int PositionId { get; set; }
        public string Name { get; set; }

        public /*virtual*/ List<Teacher> Teacher { get; set; }
    }
}
