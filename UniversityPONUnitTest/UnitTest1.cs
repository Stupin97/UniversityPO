using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversityPO.Controllers;
using UniversityPO.Domain.Dto;
using UniversityPO.Domain.Services;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace UniversityPONUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Fact]
        public async Task TestWithMoq()
        {
            var mock = new Mock<IAdminService>();

            mock.Setup(admin => admin.GetScheduleAsync(1)).Returns(Task.FromResult(GetSchedule()));

            HomeController homeController = new HomeController(null, null, null, null, mock.Object);

            var result = await homeController.AdminSchedule("1");

            Assert.IsTrue(result.Equals(typeof(ViewResult)));

            //var viewResult = Assert.IsType<ViewResult>(result);

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
    }
}