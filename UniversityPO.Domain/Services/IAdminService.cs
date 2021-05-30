namespace UniversityPO.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityPO.Domain.Dto;
    using UniversityPO.Domain.Models;

    public interface IAdminService
    {
        Task<bool> ExistStudentAsync(string studentId);

        void CreateStudent(Student student);

        void EditStudent(Student student);

        Task<Teacher_C_E_Dto> GetTeacherAsync(int teacherId);

        Task<bool> ExistTeacherAsync(int teacherId);

        void CreateTeacher(Teacher teacher);

        void EditTeacher(Teacher teacher);

        Task<ScheduleDto> GetScheduleAsync(int scheduleId);

        Task<bool> ExistScheduleAsync(int scheduleId);

        void CreateSchedule(Schedule schedule);

        void EditSchedule(Schedule schedule);
    }
}
