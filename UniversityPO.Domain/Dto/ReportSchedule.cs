namespace UniversityPO.Domain.Dto
{
    using System.Collections.Generic;

    public class ReportSchedule
    {
        public ReportSchedule()
        {
            time = new List<string>() { "08:30-10:05", "10:25-12:00", "12:40-14:15", "14:35-16:10", "16:30-18:05", "18:25-20:00", "20:20-21:55" };
        }

        public List<string> time;

        public List<ScheduleStudentDto> Shedules { get; set; }

        public List<DayOfWeekIdDto> DaysName { get; set; }

        public List<NumberLessonDto> NumbersLesson { get; set; }
    }
}
