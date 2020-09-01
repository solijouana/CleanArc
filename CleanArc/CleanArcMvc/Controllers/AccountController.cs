using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArc.Application.Interfaces;
using CleanArc.Application.ViewModels;
using CleanArc.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcMvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        public IActionResult Register()
        {
            ViewBag.UserCheck = CheckUser.Ok;
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {

                if (_userServices.CheckEmail(register.Email) == CheckUser.InvalidEmail &&
                    _userServices.CheckUserName(register.UserName) == CheckUser.InvaliUserName)
                {
                    ViewBag.UserCheck = CheckUser.InvalidUserNameandEmail;
                    return View(register);
                }
                if (_userServices.CheckUserName(register.UserName) == CheckUser.InvaliUserName)
                {
                    ViewBag.UserCheck = CheckUser.InvaliUserName;
                    return View(register);
                }
                if (_userServices.CheckEmail(register.Email) == CheckUser.InvalidEmail)
                {
                    ViewBag.UserCheck = CheckUser.InvalidEmail;
                    return View(register);
                }
                ViewBag.UserCheck = CheckUser.Ok;
                _userServices.AddUser(register);
                return RedirectToAction("Index", "Home");
            }
            return View(register);
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

    }
}