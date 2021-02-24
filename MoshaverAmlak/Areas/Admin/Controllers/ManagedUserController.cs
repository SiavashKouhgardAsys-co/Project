using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Viewmodel;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagedUserController : Controller
    {
        private readonly IUserService _userService;
        public ManagedUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        // SHOW ALL USERS
        public IActionResult Index()
        {
            SendDataToView<List<UserViewmodel>> data = new SendDataToView<List<UserViewmodel>>();
            data.Entity = _userService.
            return View();
        }

        [HttpGet()]
        // ADD NEW USER
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserViewmodel_Register register)
        {
            return  RedirectToAction("");
        }
        
    }
}
