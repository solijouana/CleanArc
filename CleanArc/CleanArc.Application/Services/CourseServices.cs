using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Application.Interfaces;
using CleanArc.Application.ViewModels;
using CleanArc.Domain.Interfaces;
using CleanArc.Domain.Models;

namespace CleanArc.Application.Services
{
    public class CourseServices:ICourseServices
    {
        private ICourseRepository _repository;

        public CourseServices(ICourseRepository repository)
        {
            _repository = repository;
        }
        public CourseViewModel GetCourses()
        {
            return new CourseViewModel()
            {
                Courses = _repository.GetAllCourses()
            };
        }

        public Course GetCourseById(int courseId)
        {
            return _repository.GetCourseById(courseId);
        }
    }
}
