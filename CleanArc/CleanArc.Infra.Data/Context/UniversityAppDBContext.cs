using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.Infra.Data.Context
{
    public class UniversityAppDBContext:DbContext
    {
        public UniversityAppDBContext(DbContextOptions<UniversityAppDBContext>options):base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }  
    }
}
