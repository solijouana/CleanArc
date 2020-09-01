using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArc.Domain.Interfaces;
using CleanArc.Domain.Models;
using CleanArc.Infra.Data.Context;

namespace CleanArc.Infra.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private UniversityAppDBContext _context;

        public UserRepository(UniversityAppDBContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
