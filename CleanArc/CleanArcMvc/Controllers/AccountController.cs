using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CleanArc.Application.Interfaces;
using CleanArc.Application.ViewModels;
using CleanArc.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public IActionResult Login(string returnUrl="/")
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (!_userServices.IsExistUser(login.Email, login.Password))
                {
                    ModelState.AddModelError("Email","The User Not found...");
                    return View(login);
                }

                var claims=new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,login.Email),
                    new Claim(ClaimTypes.NameIdentifier,login.Email)
                };

                var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal=new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = login.RememberMe,
                    RedirectUri = login.ReturnUrl
                };

                HttpContext.SignInAsync(principal, properties);
                return Redirect(login.ReturnUrl);
            }
            return View(login);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}