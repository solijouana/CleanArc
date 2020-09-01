using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArc.Application.Interfaces;
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
            return View();
        }
    }
}   