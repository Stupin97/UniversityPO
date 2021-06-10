namespace UniversityPO.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using UniversityPO.Domain;
    using UniversityPO.Domain.Models;
    using UniversityPO.Domain.Dto;

    public class AuthService : IAuthService 
    {
        private readonly UniversityContext _context;

        public AuthService(UniversityContext context)
        {
            _context = context;
        }

        public Admin GetAdminAccess(string login, string password)
        {
            var admin = Admin.GetAdmin();

            return admin.Login == login && admin.Password == password ? admin : null;
        }

        public async Task<StudentDto> GetStudentAccessAsync(string login, string password)
        {
            var student = await _context.Student
                .Include(c => c.Group)
                .Where(s => s.Login == login && s.Password == password)
                .Select(c => new StudentDto
                {
                    StudentId = c.StudentId,
                    GroupId = c.GroupId,
                    GroupName = c.Group.GroupId,
                    Name = c.Name,
                    Surname = c.Surname,
                    Phone = c.Phone,
                    Email = c.Email,
                    Login = c.Login,
                    IsHeadman = c.IsHeadman,
                    Course = c.Group.Course
                })
                .FirstOrDefaultAsync();

            return student;
        }

        public async Task<TeacherDto> GetTeacherAccessAsync(string login, string password)
        {
            var teacher = await _context.Teacher
                .Include(c => c.Discipline)
                .Where(s => s.Login == login && s.Password == password)
                .Select(c => new TeacherDto
                {
                    TeacherId = c.TeacherId,
                    DisciplineId = c.DisciplineId,
                    DisciplineName = c.Discipline.Name,
                    Name = c.Name,
                    Surname = c.Surname,
                    Phone = c.Phone,
                    Email = c.Email,
                    Login = c.Login,
                    AcademicDegree = c.AcademicDegree.Name,
                    Position = c.Position.Name
                })
                .FirstOrDefaultAsync();

            return teacher;
        }
    }
}
