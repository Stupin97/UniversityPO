using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class DeliveryType
    {
        //public DeliveryType()
        //{
        //    Discipline = new HashSet<Discipline>();
        //}

        public int DeliveryTypeId { get; set; }
        public string Name { get; set; }

        public /*virtual*/ List<Discipline> Discipline { get; set; }
    }
}
