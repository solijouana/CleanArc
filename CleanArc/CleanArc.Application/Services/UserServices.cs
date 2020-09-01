using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Application.Interfaces;
using CleanArc.Application.Security;
using CleanArc.Application.ViewModels;
using CleanArc.Domain.Interfaces;
using CleanArc.Domain.Models;

namespace CleanArc.Application.Services
{
    public class UserServices:IUserServices
    {
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int AddUser(RegisterViewModel register)
        { 
            User newUser =new User()
            {
                Email = register.Email.Trim().ToLower(),
                UserName = register.UserName.Trim().ToLower(),
                Password = PasswordHelper.EncodePasswordMd5(register.Password)
            };
            _userRepository.AddUser(newUser);
            _userRepository.Save();

            return newUser.UserId;
        }

        public CheckUser CheckUserName(string userName)
        {
            if (_userRepository.IsExistUserName(userName))
            {
                return CheckUser.InvaliUserName;
            }

            return CheckUser.Ok;
        }

        public CheckUser CheckEmail(string email)   
        {
            if (_userRepository.IsExistEmail(email))
            {
                return CheckUser.InvalidEmail;
            }

            return CheckUser.Ok;
        }
    }
}
