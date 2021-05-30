namespace UniversityPO.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityPO.Domain.Dto;
    public interface IScheduleService
    {
        Task<List<ScheduleStudentDto>> GetSchedulesForStudentAsync(string studentId);

        Task<List<ScheduleStudentDto>> GetSchedulesForTeacherAsync(int teacherId);

        Task<List<DayOfWeekIdDto>> GetDayOfWeeksName();

        Task<List<NumberLessonDto>> GetNumberLessons();
    }
}
