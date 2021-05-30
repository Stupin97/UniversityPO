namespace UniversityPO.Domain.Dto
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public string GroupId { get; set; }
        public int? DisciplineId { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassroomId { get; set; }
        public int? DayOfWeekId { get; set; }
        public int? LessonTypeId { get; set; }
        public int? NumberLessonId { get; set; }
    }
}
