using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Viewmodel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagedRoleController : Controller
    {
        private readonly IRoleService _role;
        public ManagedRoleController(IRoleService role)
        {
            _role = role;
        }

        public IActionResult Index(string resultStatus)
        {
            SendDataToView<List<RoleViewmodel>> data = new SendDataToView<List<RoleViewmodel>>();
            data.Entity = _role.GetAllRoles();
            if (resultStatus != null)
                data.Message = Result.GetMessage(resultStatus);

            return View(data);
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewmodel roleViewmodel)
        {
            var data = await _role.AddRole(roleViewmodel);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.StatusResult.ToString() }));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _role.GetRoleById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(RoleViewmodel roleViewmodel)
        {
            var role = await _role.DeleteRoleByIdAsync(roleViewmodel.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = role.StatusResult }));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _role.GetRoleById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewmodel roleViewmodel)
        {
            var role = await _role.UpdateRoleAsync(roleViewmodel);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = role.StatusResult }));
        }
    }
}
