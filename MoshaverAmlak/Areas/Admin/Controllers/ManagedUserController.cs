using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Viewmodel;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagedUserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public ManagedUserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet()]
        // SHOW ALL USERS
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<UserViewmodel>> data = new SendDataToView<IQueryable<UserViewmodel>>();
            data.Entity = _userService.GetAllUsers();
            if (!string.IsNullOrEmpty(resultStatus))
                data.Message = Result.GetMessage(resultStatus);

            return View(data);
        }

        [HttpGet()]
        // ADD NEW USER
        public IActionResult Register()
        {
            UserRolesViewmodel userRolesViewmodel = new UserRolesViewmodel();
            userRolesViewmodel.Roles = _roleService.GetAllRoles();
            return View(userRolesViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRolesViewmodel register, List<string> roleNmae)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.AddUserAsync(register.User, roleNmae);
                return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
            }
            UserRolesViewmodel userRolesViewmodel = new UserRolesViewmodel();
            userRolesViewmodel.Roles = _roleService.GetAllRoles();
            userRolesViewmodel.User = register.User;
            return View(userRolesViewmodel);
        }

    }
}
