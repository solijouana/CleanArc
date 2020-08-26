using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Domain.Models;

namespace CleanArc.Domain.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
    }
}
