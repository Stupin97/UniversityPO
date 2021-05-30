namespace UniversityPO.Domain.Services
{
    using System.Threading.Tasks;

    using UniversityPO.Domain.Dto;

    public interface IAuthService
    {
        Task<TeacherDto> GetTeacherAccessAsync(string login, string password);

        Task<StudentDto> GetStudentAccessAsync(string login, string password);

        Task<Admin> GetAdminAccessAsync(string login, string password);
    }
}
