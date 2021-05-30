namespace UniversityPO.Domain.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UniversityPO.Domain.Dto;
    using UniversityPO.Domain.Models;

    public class AdminService : IAdminService
    {
        private readonly UniversityContext _context;

        public AdminService(UniversityContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistStudentAsync(string studentId)
        {
            return await _context.Student.AnyAsync(c => c.StudentId == studentId);
        }

        public void CreateStudent(Student student)
        {
            _context.Student.Add(student);

            _context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            _context.Student.Update(student);

            _context.SaveChanges();
        }

        public async Task<Teacher_C_E_Dto> GetTeacherAsync(int teacherId)
        {
            return await _context.Teacher
                .Where(c => c.TeacherId == teacherId)
                .Select(c => new Teacher_C_E_Dto
                {
                    TeacherId = c.TeacherId,
                    DisciplineId = c.DisciplineId,
                    Name = c.Name,
                    Surname = c.Surname,
                    PositionId = c.PositionId,
                    Phone = c.Phone,
                    Email = c.Email,
                    Login = c.Login,
                    AcademicDegreeId = c.AcademicDegreeId,
                    Password = c.Password                
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistTeacherAsync(int teacherId)
        {
            return await _context.Teacher.AnyAsync(c => c.TeacherId == teacherId);
        }

        public void CreateTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);

            _context.SaveChanges();
        }

        public void EditTeacher(Teacher teacher)
        {
            _context.Teacher.Update(teacher);

            _context.SaveChanges();
        }

        public async Task<ScheduleDto> GetScheduleAsync(int scheduleId)
        {
            return await _context.Schedule
                .Where(c => c.ScheduleId == scheduleId)
                .Select(c => new ScheduleDto
                {
                    ScheduleId = c.ScheduleId,
                    GroupId = c.GroupId,
                    DisciplineId = c.DisciplineId,
                    TeacherId = c.TeacherId,
                    DayOfWeekId = c.DayOfWeekId,
                    ClassroomId = c.ClassroomId,
                    LessonTypeId = c.LessonTypeId,
                    NumberLessonId = c.NumberLessonId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistScheduleAsync(int scheduleId)
        {
            return await _context.Schedule.AnyAsync(c => c.ScheduleId == scheduleId);
        }

        public void CreateSchedule(Schedule schedule)
        {
            _context.Schedule.Add(schedule);

            _context.SaveChanges();
        }

        public void EditSchedule(Schedule schedule)
        {
            _context.Schedule.Update(schedule);

            _context.SaveChanges();
        }
    }
}
