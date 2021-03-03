using Microsoft.AspNetCore.Mvc;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var data = _ownerService.GetAllOwners();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = data.Entity;
            if (sendDataToView != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Owner owner)
        {
            var result = await _ownerService.CreateOwner(owner);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete() => View();
        [HttpGet]
        public IActionResult Edit() => View();
    }
}
