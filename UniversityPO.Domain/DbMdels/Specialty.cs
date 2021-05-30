using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Specialty
    {
        //public Specialty()
        //{
        //    Group = new HashSet<Group>();
        //}

        public int SpecialtyId { get; set; }
        public string Name { get; set; }

        public /*virtual*/ List<Group> Group { get; set; }
    }
}
