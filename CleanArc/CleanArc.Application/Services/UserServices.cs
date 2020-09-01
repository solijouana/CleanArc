using System;
using System.Collections.Generic;
using System.Text;
using CleanArc.Application.Interfaces;
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
        public int AddUser(User user)
        {
            User newUser = user;
            _userRepository.AddUser(newUser);
            _userRepository.Save();

            return newUser.UserId;
        }

        public CheckUser IsexistUserName(string userName)
        {
            if (_userRepository.IsExistUserName(userName))
            {
                return CheckUser.InvaliUserName;
            }

            return CheckUser.Ok;
        }

        public CheckUser IsExistEmail(string email)
        {
            if (_userRepository.IsExistEmail(email))
            {
                return CheckUser.InvalidEmail;
            }

            return CheckUser.Ok;
        }
    }
}
