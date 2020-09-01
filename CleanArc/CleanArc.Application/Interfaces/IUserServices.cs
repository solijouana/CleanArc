using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Application.ViewModels;
using CleanArc.Domain.Models;

namespace CleanArc.Application.Interfaces
{
    public interface IUserServices
    {
        int AddUser(RegisterViewModel register);
        CheckUser CheckUserName(string userName);
        CheckUser CheckEmail(string email);
    }
}
