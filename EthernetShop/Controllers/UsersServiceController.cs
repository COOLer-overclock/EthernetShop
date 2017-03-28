using EthernetShop.BLL.Interfaces;
using EthernetShop.BLL.DTO;
using EthernetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EthernetShop.Attributes;
using EU = EthernetShop.Util;

namespace EthernetShop.Controllers
{
    namespace EthernetShop.Controllers.Users
    {
        public class UsersServiceController : Controller
        {
            private IUserService userService;
            public UsersServiceController(IUserService userService)
            {
                this.userService = userService;
            }
            [HttpGet]
            public ActionResult RegistrationUser()
            {
                return View(new UserAddViewModel());
            }
            [HttpPost]
            public ActionResult RegistrationUser(UserAddViewModel userAddViewModel)
            {
                if (userAddViewModel != null)
                {
                    userService.AddUser(EU.AutoMapper.Mapper.Map<UserAddViewModel, UserAddDTO>(userAddViewModel));
                }
                return RedirectToAction("Index", "Home");
            }
            [HttpGet]
            public ActionResult LogIn()
            {
                return View(new UserLogInViewModel());
            }
            [HttpPost]
            public ActionResult LogIn(UserLogInViewModel userLogInViewModel)
            {
                if (userService.UserLogIn(EU.AutoMapper.Mapper.Map<UserLogInViewModel, UserLogInDTO>(userLogInViewModel)))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Content("Ошибка авторизации.");
            }

            [Authorized]
            public ActionResult LogOut()
            {
                userService.UserLogOut();
                return RedirectToAction("Index", "Home");
            }

            [Authorized (Roles = "Developer, Admin")]
            public ActionResult ShowUsers()
            {
                return View(EU.AutoMapper.Mapper.Map<IEnumerable<UserDTO>, IEnumerable<UserShowViewModel>>(userService.GetUsers()));
            }
        }
    }
}