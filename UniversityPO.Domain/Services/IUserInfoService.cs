namespace UniversityPO.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityPO.Domain.Dto;

    public interface IUserInfoService
    {
        Task<List<AcademicPerfomanceDto>> GetAcademicPerfomanceAsync(string studentId);

        Task<StudentDto> GetStudentByIdAsync(string studentId);

        Task<TeacherDto> GetTeacherByIdAsync(int teacherId);

        Task<List<TeacherInfoDto>> GetInfoTeachers();
    }
}
