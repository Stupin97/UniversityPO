using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Faculty
    {
        //public Faculty()
        //{
        //    Group = new HashSet<Group>();
        //}

        public int FacultyId { get; set; }
        public string Name { get; set; }

        public /*virtual*/ List<Group> Group { get; set; }
    }
}
