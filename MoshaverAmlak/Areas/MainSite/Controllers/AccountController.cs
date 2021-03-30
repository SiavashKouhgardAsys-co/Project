using Microsoft.AspNetCore.Mvc;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.MainSite.Controllers
{
    [Area("MainSite")]
    public class AccountController : Controller
    {
        private readonly IUserService _user;
        public AccountController(IUserService user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewmodel_Login userViewmodel_Login)
        {
            var login = await _user.Login(userViewmodel_Login);
            if (login.StatusResult != (int)Result.Status.LoginOk) return RedirectToAction("Login");
            return RedirectToAction("Index", "Dashboard", new { area = "User" });
        }
    }
}
