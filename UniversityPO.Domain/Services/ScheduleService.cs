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
    public class ScheduleService : IScheduleService
    {
        private readonly UniversityContext _context;

        public ScheduleService(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleStudentDto>> GetSchedulesForStudentAsync(string studentId)
        {
            var student = await _context.Student
                .Where(c => c.StudentId == studentId)
                .FirstOrDefaultAsync();

            if (student != null)
            {
                return _context.Schedule
                    .Include(c => c.Group)
                    .Include(c => c.LessonType)
                    .Include(c => c.NumberLesson)
                    .Include(c => c.Teacher)
                    .Include(c => c.Discipline)
                    .Include(c => c.DayOfWeek)
                    .Include(c => c.Classroom)
                    .Where(c => c.GroupId == student.GroupId)
                    .OrderBy(c => c.DayOfWeekId)
                    .Select(c => new ScheduleStudentDto
                    {
                        ScheduleId = c.ScheduleId,
                        GroupId = c.GroupId,
                        Name = student.Name,
                        Surname = student.Surname,
                        DisciplineId = c.DisciplineId,
                        DisciplineName = c.Discipline.Name,
                        TeacherId = c.TeacherId,
                        TeacherName = c.Teacher.Name,
                        TeacherSurname = c.Teacher.Surname,
                        ClassroomId = c.ClassroomId,
                        Classroom = c.Classroom.Address + ": ауд.: " + c.Classroom.NumberRoom,
                        DayOfWeekId = c.DayOfWeekId,
                        DayOfWeek = c.DayOfWeek.Name,
                        LessonTypeId = c.LessonTypeId,
                        LessonType = c.LessonType.Name,
                        NumberLessonId = c.NumberLessonId,
                    })
                    .ToList();
            }

            return null;
        }

        public async Task<List<ScheduleStudentDto>> GetSchedulesForTeacherAsync(int teacherId)
        {
            var teacher = await _context.Teacher
                .Where(c => c.TeacherId == teacherId)
                .FirstOrDefaultAsync();

            if (teacher != null)
            {
                return _context.Schedule
                    .Include(c => c.Group)
                    .Include(c => c.LessonType)
                    .Include(c => c.NumberLesson)
                    .Include(c => c.Teacher)
                    .Include(c => c.Discipline)
                    .Include(c => c.DayOfWeek)
                    .Include(c => c.Classroom)
                    .Where(c => c.TeacherId == teacher.TeacherId)
                    .OrderBy(c => c.DayOfWeekId)
                    .Select(c => new ScheduleStudentDto
                    {
                        ScheduleId = c.ScheduleId,
                        GroupId = c.GroupId,
                        DisciplineId = c.DisciplineId,
                        DisciplineName = c.Discipline.Name,
                        TeacherId = c.TeacherId,
                        TeacherName = teacher.Name,
                        TeacherSurname = teacher.Surname,
                        ClassroomId = c.ClassroomId,
                        Classroom = c.Classroom.Address + ": ауд.: " + c.Classroom.NumberRoom,
                        DayOfWeekId = c.DayOfWeekId,
                        DayOfWeek = c.DayOfWeek.Name,
                        LessonTypeId = c.LessonTypeId,
                        LessonType = c.LessonType.Name,
                        NumberLessonId = c.NumberLessonId,
                    })
                    .ToList();
            }

            return null;
        }
        public async Task<List<DayOfWeekIdDto>> GetDayOfWeeksName()
        {
            return await _context.DayOfWeekId
                .Select(c => new DayOfWeekIdDto
                {
                    DayOfWeekId1 = c.DayOfWeekId1,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<List<NumberLessonDto>> GetNumberLessons()
        {
            return await _context.NumberLesson
                .Select(c => new NumberLessonDto
                {
                    NumberLessonId = c.NumberLessonId,
                    StartLessonDate = c.StartLessonDate,
                    EndLessonDate =c.EndLessonDate
                })
                .ToListAsync();
        }
    }
}
