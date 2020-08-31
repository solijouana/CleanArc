using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Application.ViewModels;
using CleanArc.Domain.Models;

namespace CleanArc.Application.Interfaces
{
    public interface ICourseServices
    {
        CourseViewModel GetCourses();
        Course GetCourseById(int courseId);
    }
}
