namespace UniversityPO.Domain.Dto
{
    public class ScheduleStudentDto
    {
        public int ScheduleId { get; set; }
        public string GroupId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public int? TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public int? ClassroomId { get; set; }
        public string Classroom { get; set; }
        public int? DayOfWeekId { get; set; }
        public string DayOfWeek { get; set; }
        public int? LessonTypeId { get; set; }
        public string LessonType { get; set; }
        public int? NumberLessonId { get; set; }
    }
}
