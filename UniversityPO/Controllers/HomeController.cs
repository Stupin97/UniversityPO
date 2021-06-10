using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UniversityPO.Domain;
using UniversityPO.Domain.Dto;
using UniversityPO.Domain.Models;
using UniversityPO.Domain.Services;
using UniversityPO.Models;

namespace UniversityPO.Controllers
{
    public class HomeController : Controller
    {
        private static string typeUser = "";
        private static string StudentId = "";
        private static int TeacherId = 0;

        //private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;
        private readonly IUserInfoService _userInfoService;
        private readonly INewsService _newsService;
        private readonly IScheduleService _scheduleService;
        private readonly IAdminService _adminService;

        public HomeController(/*ILogger<HomeController> logger,*/ IAuthService authService,
            IUserInfoService userInfoService, INewsService newsService,
            IScheduleService scheduleService, IAdminService adminService)
        {
            //_logger = logger;
            _authService = authService;
            _userInfoService = userInfoService;
            _newsService = newsService;
            _scheduleService = scheduleService;
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return Redirect("~/Home/Auth");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/Auth")]
        [HttpGet]
        public async Task<IActionResult> Auth()
        {
            return this.View("Auth");
        }

        [Route("Home/Auth")]
        [HttpPost]
        public async Task<IActionResult> Auth(string choice, string login, string password)
        {
            string date = Helpers.GetDateTime(DateTime.Now);

            switch (choice)
            {
                case "teacher":
                    var resultT = await _authService.GetTeacherAccessAsync(login, password);
                    if (resultT != null)
                    {
                        typeUser = "teacher";

                        TeacherId = resultT.TeacherId;

                        return View("PersonalPageTeacher", resultT);
                        //return RedirectToAction("PersonalPageTeacher", "Home", resultT);
                    }
                    break;
                case "student":
                    var resultS = await _authService.GetStudentAccessAsync(login, password);
                    if (resultS != null)
                    {
                        typeUser = "student";

                        StudentId = resultS.StudentId;
                        
                        return View("PersonalPageStudent", resultS);
                        //return RedirectToAction("Schedule", "Home", resultS);
                    }
                    break;
                case "admin":
                    var resultA = _authService.GetAdminAccess(login, password);
                    if (resultA != null)
                    {
                        typeUser = "admin";

                        return View("PersonalPageAdmin");
                        //return RedirectToAction("PersonalPageAdmin", "Home", resultA);
                    }
                    break;
            }

            ViewBag.Message = "Пользователь не найден! Попробуйте снова.";

            return this.View("Auth");
        }

        [Route("Home/PersonalPage")]
        [HttpGet]
        public async Task<IActionResult> PersonalPage(string userId)
        {
            ViewBag.userId = typeUser == "teacher" ? TeacherId.ToString() : StudentId;

            if (typeUser == "teacher")
            {
                //var result = await _userInfoService.GetTeacherByIdAsync(Int32.Parse(userId));
                var result = await _userInfoService.GetTeacherByIdAsync(userId);

                return View("PersonalPageTeacher", result);
            }
            else
            {
                var result = await _userInfoService.GetStudentByIdAsync(userId);

                return View("PersonalPageStudent", result);
            }
        }

        [Route("Home/AcademicPerfomance")]
        [HttpGet]
        public async Task<IActionResult> StudentAcademicPerfomance(string studentId)
        {
            var result = await _userInfoService.GetAcademicPerfomanceAsync(studentId);

            if(result != null)
            {
                if(result.Count != 0)
                    ViewBag.Group = result[0].GroupName;

                ViewBag.StudentId = StudentId;

                return View("StudentAcademicPerfomance", result);
            }

            return View("Error", new ErrorViewModel { RequestId = "200"}); 
        }

        [Route("Home/TeachersList")]
        [HttpGet]
        public async Task<IActionResult> TeachersList()
        {
            var result = await _userInfoService.GetInfoTeachers();

            if (result != null && result.Count != 0)
            {
                ViewBag.TypeUser = typeUser;

                ViewBag.StudentId = StudentId;

                ViewBag.userId = typeUser == "teacher" ? TeacherId.ToString() : StudentId;

                return View("TeachersList", result);
            }

            return View("Error", new ErrorViewModel { RequestId = "200" });
        }

        [Route("Home/News")]
        [HttpGet]
        public IActionResult News()
        {
            var result = _newsService.GetAllEvents();

            if (result != null)
            {
                ViewBag.TypeUser = typeUser;

                ViewBag.StudentId = StudentId;

                ViewBag.userId = typeUser == "teacher" ? TeacherId.ToString() : StudentId;

                return View("News", result);
            }

            return View("Error", new ErrorViewModel { RequestId = "200" });
        }

        [Route("Home/Schedule")]
        [HttpGet]
        public async Task<IActionResult> Schedule(string userId)
        {
            ReportSchedule reportSchedule = new ReportSchedule();

            ViewBag.TypeUser = typeUser;

            ViewBag.StudentId = StudentId;

            ViewBag.userId = typeUser == "teacher" ? TeacherId.ToString() : StudentId;

            reportSchedule.DaysName = await _scheduleService.GetDayOfWeeksName();
            reportSchedule.NumbersLesson = await _scheduleService.GetNumberLessons();

            if (typeUser == "teacher")
            {
                reportSchedule.Shedules = await _scheduleService.GetSchedulesForTeacherAsync(Int32.Parse(userId));

                return View("Schedule", reportSchedule);
            }
            else
            {
                reportSchedule.Shedules = await _scheduleService.GetSchedulesForStudentAsync(userId);

                return View("Schedule", reportSchedule);
            }
        }

        private static bool isCreate = false;

        [Route("Home/AdminStudent")]
        [HttpGet]
        public async Task<IActionResult> AdminStudent(string studentId = "")
        {
            if (studentId != "")
            {
                var result = await _userInfoService.GetStudentByIdAsync(studentId);

                if(result == null)
                {
                    ViewBag.Mes = "Не найден!";

                    return View("PersonalPageAdmin");
                }

                isCreate = false;

                return View("AdminStudent", result);
            }

            isCreate = true;

            return View("AdminStudent", null);
        }

        [Route("Home/AdminStudent")]
        [HttpPost]
        public async Task<IActionResult> AdminStudent(Student student)
        {
            if (student != null)
            {
                if (student.Email == null || student.GroupId == null || student.IsHeadman == null || student.Login == null || student.Name == null || student.Password == null || student.Phone == null || student.Surname == null)
                {
                    ViewBag.Done = "Некорректные данные!";

                    return View("PersonalPageAdmin");
                }

                if (isCreate)
                {
                    var exStudent = await _adminService.ExistStudentAsync(student.StudentId);

                    if (!exStudent)
                    {
                        _adminService.CreateStudent(student);

                        ViewBag.Done = "Успешное добавление!";
                    }
                    else
                    {
                        ViewBag.Done = "Добавление неудачно!";
                    }
                }
                else
                {
                    //Для случая, если администратор изменил поле ID 
                    var exStudent = await _adminService.ExistStudentAsync(student.StudentId);

                    if (exStudent)
                    {
                        _adminService.EditStudent(student);

                        ViewBag.Done = "Успешное редактирование!";
                    }
                    else
                    {
                        ViewBag.Done = "Изменение неудачно!";
                    }
                }
            }

            return View("PersonalPageAdmin");
        }

        [Route("Home/AdminTeacher")]
        [HttpGet]
        public async Task<IActionResult> AdminTeacher(string teacherId = "")
        {
            try 
            { 
                if (teacherId != "")
                {
                    var result = await _adminService.GetTeacherAsync(Int32.Parse(teacherId));

                    if (result == null)
                    {
                        ViewBag.MesTeacher = "Не найден!";

                        return View("PersonalPageAdmin");
                    }

                    isCreate = false;

                    return View("AdminTeacher", result);
                }

                isCreate = true;

                return View("AdminTeacher", null);
            }
            catch (FormatException ex)
            {
                throw;
            }
        }

        [Route("Home/AdminTeacher")]
        [HttpPost]
        public async Task<IActionResult> AdminTeacher(Teacher teacher)
        {
            if (teacher != null)
            {
                if (teacher.AcademicDegreeId == null || teacher.DisciplineId == null || teacher.Email == null || teacher.Login == null || teacher.Name == null || teacher.Password == null || teacher.Phone == null || teacher.PositionId == null || teacher.Surname == null)
                {
                    ViewBag.Done = "Некорректные данные!";

                    return View("PersonalPageAdmin");
                }

                if (isCreate)
                {
                    var exTeacher = await _adminService.ExistTeacherAsync(teacher.TeacherId);

                    if (!exTeacher)
                    {
                        _adminService.CreateTeacher(teacher);

                        ViewBag.Done = "Успешное добавление!";
                    }
                    else
                    {
                        ViewBag.Done = "Добавление неудачно!";
                    }
                }
                else
                {
                    //Для случая, если администратор изменил поле ID 
                    var exTeacher = await _adminService.ExistTeacherAsync(teacher.TeacherId);

                    if (exTeacher)
                    {
                        _adminService.EditTeacher(teacher);

                        ViewBag.Done = "Успешное редактирование!";
                    }
                    else
                    {
                        ViewBag.Done = "Изменение неудачно!";
                    }
                }
            }

            return View("PersonalPageAdmin");
        }

        [Route("Home/AdminSchedule")]
        [HttpGet]
        public async Task<ActionResult> AdminSchedule(string scheduleId = "")
        {
            if (scheduleId != "")
            {
                var result = await _adminService.GetScheduleAsync(Int32.Parse(scheduleId));

                if (result == null)
                {
                    ViewBag.MesSchedule = "Не найден!";

                    return View("PersonalPageAdmin");
                }

                isCreate = false;

                return View("AdminSchedule", result);
            }

            isCreate = true;

            return View("AdminSchedule", null);
        }

        [Route("Home/AdminSchedule")]
        [HttpPost]
        public async Task<IActionResult> AdminSchedule(Schedule schedule)
        {
            if (schedule != null)
            {
                if (schedule.ClassroomId == null || schedule.DayOfWeekId == null || schedule.DisciplineId == null || schedule.GroupId == null || schedule.LessonTypeId == null || schedule.NumberLessonId == null || schedule.TeacherId == null)
                {
                    ViewBag.Done = "Некорректные данные!";

                    return View("PersonalPageAdmin");
                }

                if (isCreate)
                {
                    var exSchedule = await _adminService.ExistScheduleAsync(schedule.ScheduleId);

                    if (!exSchedule)
                    {
                        _adminService.CreateSchedule(schedule);

                        ViewBag.Done = "Успешное добавление!";
                    }
                    else
                    {
                        ViewBag.Done = "Добавление неудачно!";
                    }
                }
                else
                {
                    //Для случая, если администратор изменил поле ID 
                    var exTeacher = await _adminService.ExistScheduleAsync(schedule.ScheduleId);

                    if (exTeacher)
                    {
                        _adminService.EditSchedule(schedule);

                        ViewBag.Done = "Успешное редактирование!";
                    }
                    else
                    {
                        ViewBag.Done = "Изменение неудачно!";
                    }
                }
            }

            return View("PersonalPageAdmin");
        }
    }
}
