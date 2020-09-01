using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcMvc.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ICourseServices _courseServices;

        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        public IActionResult Index()
        {
            return View(_courseServices.GetCourses());
        }

        public IActionResult ShowCours(int id)
        {
            var course = _courseServices.GetCourseById(id);
            if (course == null) return NotFound();
            return View(course);
        }
    }
}