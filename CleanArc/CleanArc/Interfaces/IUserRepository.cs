using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Domain.Models;

namespace CleanArc.Domain.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        void Save();
    }
}
