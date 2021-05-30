namespace UniversityPO.Domain.Dto
{
    public class Teacher_C_E_Dto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? DisciplineId { get; set; }
        public int? PositionId { get; set; }
        public int? AcademicDegreeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
