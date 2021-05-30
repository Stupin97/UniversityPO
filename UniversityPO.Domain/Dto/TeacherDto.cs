namespace UniversityPO.Domain.Dto
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string AcademicDegree { get; set; }
        public string Position { get; set; }

        //public AcademicDegree AcademicDegree { get; set; }
        //public Discipline Discipline { get; set; }
        //public Position Position { get; set; }
        //public List<AcademicPerfomance> AcademicPerfomance { get; set; }
    }
}
