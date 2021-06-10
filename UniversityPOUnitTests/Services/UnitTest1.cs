using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPO.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityPO.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using System.Threading.Tasks;
using UniversityPO.Controllers;
using Microsoft.AspNetCore.Mvc;
using Couchbase.Views;

namespace UniversityPO.Domain.Services.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //[ExpectedException(typeof(FormatException))]
        public void GetAdminAccessAsyncTest()
        {
            //UniversityContext context = new UniversityContext();

            //UserInfoService userInfoService = new UserInfoService(context);

            //var res = userInfoService.GetTeacherByIdAsync("!!!!");
            //MyAssert.Throws<FormatException>(async () => await userInfoService.GetTeacherByIdAsync("4dfdfd"));
        }


        [TestMethod]
        public void GetSortEvents()
        {
            //NewsService newsService = new NewsService(new UniversityContext(new DbContextOptions<UniversityContext>()));

            //var result = newsService.GetAllEvents();

            //Assert.AreEqual(result, typeof(List<EventDto>));
        }

        [TestMethod()]
        public void GetSortEventsTest()
        {
            NewsService newsService = new NewsService();

            List<EventDto> eventsDto = new List<EventDto>
            {
                new EventDto (){ EventId = 1, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = "first"},
                new EventDto (){ EventId = 2, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = "second"},
                new EventDto (){ EventId = 3, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = ""},
                new EventDto (){ EventId = 4, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = ""}
            };

            var result = newsService.GetSortEvents(eventsDto);
            Assert.IsTrue(result is List<EventDto>);

            //Временный пункт, для проверки "исключения" пустой новости 
            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod()]
        public void isFirstThreeIsImportantEventsTest()
        {
            NewsService newsService = new NewsService();

            List<EventDto> eventsDto = new List<EventDto>
            {
                new EventDto (){ EventId = 1, DatePublic = DateTime.Now, IsImportant = true, IsUrgently = true, Text = "1"},
                new EventDto (){ EventId = 2, DatePublic = DateTime.Now, IsImportant = true, IsUrgently = true, Text = "2"},
                new EventDto (){ EventId = 3, DatePublic = DateTime.Now, IsImportant = true, IsUrgently = true, Text = "3"},
                new EventDto (){ EventId = 3, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = "4"},
                new EventDto (){ EventId = 3, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = "5"},
                new EventDto (){ EventId = 3, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = "6"},
                new EventDto (){ EventId = 3, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = "7"},
                new EventDto (){ EventId = 4, DatePublic = DateTime.Now, IsImportant = false, IsUrgently = true, Text = "8"}
            };

            var result = newsService.isFirstThreeIsImportantEvents(eventsDto);

            Assert.IsTrue(result is true);
        }

        [TestMethod]
        public async Task TestWithMoq()
        {
            var mockAdmin = new Mock<IAdminService>();

            var mockAuth = new Mock<IAuthService>();

            var mockInfo = new Mock<IUserInfoService>();

            var mockNews = new Mock<INewsService>();

            var mockSchedule = new Mock<IScheduleService>();

            mockAdmin.Setup(admin => admin.GetScheduleAsync(1)).Returns(Task.FromResult(GetSchedule()));

            mockAuth.Setup(auth => auth.GetStudentAccessAsync("1", "pas")).Returns(Task.FromResult(GetStudent()));

            mockInfo.Setup(info => info.GetStudentByIdAsync("pas")).Returns(Task.FromResult(GetStudent()));

            mockNews.Setup(news => news.GetAllEvents()).Returns(GetAllEvent());

            mockSchedule.Setup(schedule => schedule.GetSchedulesForStudentAsync("12")).Returns(Task.FromResult(studentDtos("12")));

            HomeController homeController = new HomeController(mockAuth.Object, mockInfo.Object, mockNews.Object, mockSchedule.Object, mockAdmin.Object);

            var result = await homeController.AdminSchedule("1");

            Assert.IsTrue(result is ActionResult);
        }

        private ScheduleDto GetSchedule()
        {
            return new ScheduleDto
            {
                ScheduleId = 1,
                ClassroomId = 1,
                DayOfWeekId = 1,
                DisciplineId = 1,
                GroupId = "11",
                LessonTypeId = 1,
                NumberLessonId = 1,
                TeacherId = 1
            };
        }

        private StudentDto GetStudent()
        {
            return new StudentDto
            {
                Course = 1,
                Email = "sd",
                GroupId = "sds",
                GroupName = "sdd",
                IsHeadman = false,
                Login = "sd",
                Name = "sdsd",
                Password = "sdsd",
                Phone = "sd",
                StudentId = "sdd",
                Surname = "sdd"
            };
        }

        private List<EventDto> GetAllEvent()
        {
            return new List<EventDto>()
            {
                new EventDto
                {
                    DatePublic = DateTime.Now,
                    EventId = 1,
                    IsImportant = false,
                    IsUrgently = true,
                    Text = "sd"
                },
                new EventDto
                {
                    DatePublic = DateTime.Now,
                    EventId = 2,
                    IsImportant = false,
                    IsUrgently = true,
                    Text = "sd"
                }
            };
        }

        private List<ScheduleStudentDto> studentDtos(string studentId)
        {
            return new List<ScheduleStudentDto>()
            {

            };
        }
    }

    public static class MyAssert
    {
        public static void Throws<T>(Action func) where T : Exception
        {
            var exceptionThrown = false;
            try
            {
                func.Invoke();
            }
            catch (T)
            {
                exceptionThrown = true;
            }

            if (!exceptionThrown)
            {
                throw new AssertFailedException(
                    String.Format("An exception of type {0} was expected, but not thrown", typeof(T))
                    );
            }
        }
    }
}