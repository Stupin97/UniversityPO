using System;
using System.Collections.Generic;

namespace UniversityPO.Domain.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string GroupId { get; set; }
        public int? DisciplineId { get; set; }
        public int? TeacherId { get; set; }
        public int? ClassroomId { get; set; }
        public int? DayOfWeekId { get; set; }
        public int? LessonTypeId { get; set; }
        public int? NumberLessonId { get; set; }

        public /*virtual*/ Classroom Classroom { get; set; }
        public /*virtual*/ DayOfWeekId DayOfWeek { get; set; }
        public /*virtual*/ Discipline Discipline { get; set; }
        public /*virtual*/ Group Group { get; set; }
        public /*virtual*/ LessonType LessonType { get; set; }
        public /*virtual*/ NumberLesson NumberLesson { get; set; }
        public /*virtual*/ Teacher Teacher { get; set; }
    }
}
