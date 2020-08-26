using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Models
{
   public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public string ImageUrl { get; set; }    
    }
}
