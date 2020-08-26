using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Domain.Models;

namespace CleanArc.Application.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }    
    }
}
