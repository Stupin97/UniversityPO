namespace UniversityPO.Domain.Dto
{
    public class StudentDto
    {
        public string StudentId { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool? IsHeadman { get; set; }
        public int? Course { get; set; }

        //public Group Group { get; set; }
        //public List<AcademicPerfomance> AcademicPerfomance { get; set; }
    }
}
