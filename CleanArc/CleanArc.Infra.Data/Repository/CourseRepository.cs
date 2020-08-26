using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Domain.Interfaces;
using CleanArc.Domain.Models;
using CleanArc.Infra.Data.Context;

namespace CleanArc.Infra.Data.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private UniversityAppDBContext _context;

        public CourseRepository(UniversityAppDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses;
        }
    }
}
