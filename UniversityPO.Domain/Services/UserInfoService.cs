namespace UniversityPO.Domain.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UniversityPO.Domain.Dto;

    public class UserInfoService : IUserInfoService
    {
        private readonly UniversityContext _context;

        public UserInfoService(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<AcademicPerfomanceDto>> GetAcademicPerfomanceAsync(string studentId){
            var student = await _context.Student
                .Where(c => c.StudentId == studentId)
                .FirstOrDefaultAsync();

            if(student != null)
            {
                var academicPerfomance = await _context.AcademicPerfomance
                    .Include(c => c.Student)
                    .Include(c => c.Discipline)
                    .Include(c => c.Teacher)
                    .Where(c => c.StudentId == student.StudentId)
                    .Select(c => new AcademicPerfomanceDto {
                        AcademicPerfomanceId = c.AcademicPerfomanceId,
                        StudentId = c.StudentId,
                        GroupName = student.GroupId,
                        StudentName = c.Student.Name,
                        StudentSurname = c.Student.Surname,
                        Semester = c.Semester,
                        DisciplineId = c.DisciplineId,
                        DisciplineName = c.Discipline.Name,
                        Rating = c.Rating,
                        DateReceiptRating = c.DateReceiptRating,
                        TeacherId = c.TeacherId,
                        TeacherName = c.Teacher.Name,
                        TeacherSurname = c.Teacher.Surname
                    })
                    .ToListAsync();

                return academicPerfomance;
            }

            return null;
        }

        public async Task<List<TeacherInfoDto>> GetInfoTeachers()
        {
            return await _context.Teacher
                .Include(c => c.Discipline)
                .Include(c => c.Position)
                .Include(c => c.AcademicDegree)
                .Select(c => new TeacherInfoDto
                {
                    TeacherId = c.TeacherId,
                    AcademicDegree = c.AcademicDegree.Name,
                    Name = c.Name,
                    Surname = c.Surname,
                    Position = c.Position.Name,
                    DisciplineName = c.Discipline.Name,
                    Email = c.Email,
                    Phone = c.Phone
                })
                .ToListAsync();
        }

        public async Task<StudentDto> GetStudentByIdAsync(string studentId)
        {
            return await _context.Student
                .Where(c => c.StudentId == studentId)
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
                    Password = c.Password,
                    Course = c.Group.Course
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int teacherId)
        {
            return await _context.Teacher
                .Where(c => c.TeacherId == teacherId)
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
        }
    }
}
