namespace UniversityPO.Domain.Dto
{
    using System;

    public class GroupDto
    {
        public string GroupId { get; set; }
        public int? FacultyId { get; set; }
        public int? SpecialtyId { get; set; }
        public int? Course { get; set; }
        public DateTime? DateReceipt { get; set; }

        //public Faculty Faculty { get; set; }
        //public Specialty Specialty { get; set; }
        //public List<Student> Student { get; set; }
    }
}
