using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.User.Controllers
{
    [Area("User")]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<Owner>> sendDataToView = new SendDataToView<IQueryable<Owner>>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _ownerService.GetAllOwners(userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = _ownerService.GetOwnerById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Owner owner)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            owner.UserId = userId;
            var result = await _ownerService.CreateOwner(owner);
            return RedirectToAction("Index" , new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = _ownerService.GetOwnerById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Owner owner)
        {
            var result = await _ownerService.DeleteOwner(owner.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatsu = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _ownerService.GetOwnerById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Owner owner)
        {
            var result = await _ownerService.EditOwner(owner);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
    }
}
