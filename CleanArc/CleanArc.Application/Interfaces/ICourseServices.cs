using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Application.ViewModels;

namespace CleanArc.Application.Interfaces
{
    public interface ICourseServices
    {
        CourseViewModel GetCourses();
    }
}
