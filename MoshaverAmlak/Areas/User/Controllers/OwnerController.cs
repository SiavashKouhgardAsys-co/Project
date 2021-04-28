using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
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
            SendDataToView<List<OwnerViewmodel>> sendDataToView = new SendDataToView<List<OwnerViewmodel>>();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _ownerService.GetAllOwners(userId);
            //if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _ownerService.GetOwnerByIdForDetails(id, userId);
            //if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(OwnerViewmodel ownerViewmodel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _ownerService.CreateOwner(new Owner() 
            {
                UserId = userId,
                Id = ownerViewmodel.Id,
                FullName = ownerViewmodel.FullName,
                Descrption = ownerViewmodel.Description
            });
            return RedirectToAction("Index" , new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
        
        [HttpGet]
        public IActionResult CreateOwnerTel(int ownerId , string statusResult = null)
        {
            SendDataToView<List<OwnerViewmodel>> sendDataToView = new SendDataToView<List<OwnerViewmodel>>();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = _ownerService.GetOwnerById(ownerId, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            var tels = _ownerService.GetAllOwnerTelByUserId(ownerId);
            if (tels.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = tels.Result.StatusResult }));
            OwnerTelViewmodel ownerTelViewmodel = new OwnerTelViewmodel()
            {
                Owner = data.Entity,
                Tels = tels.Entity,
                OwnerInfo = new OwnerTel()
            };
            if (statusResult != null)
                sendDataToView.Message = Result.GetMessage(statusResult);
            return View(ownerTelViewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwnerTel(OwnerTelViewmodel ownerTelViewmodel)
        {
            var result = await _ownerService.CreateOwnerTel(new OwnerTel()
            {
                OwnerId = ownerTelViewmodel.OwnerInfo.OwnerId,
                Tel = ownerTelViewmodel.OwnerInfo.Tel
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
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
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOwnerTel(string telId, string ownerId)
        {
            var result = await _ownerService.DeleteOwnerTel(int.Parse(telId));
            return RedirectToAction("CreateOwnerTel", new RouteValueDictionary(new { ownerId = ownerId, resultStatus = result.StatusResult}));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _ownerService.GetOwnerById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            OwnerViewmodel ownerViewmodel = new OwnerViewmodel()   
            {
                Id = data.Entity.Id,
                FullName = data.Entity.FullName,
                Description = data.Entity.Descrption 
            };
            return View(ownerViewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OwnerViewmodel ownerViewmodel)
        {
            var result = await _ownerService.EditOwner(new Owner() 
            {
                Id = ownerViewmodel.Id,
                FullName = ownerViewmodel.FullName,
                Descrption = ownerViewmodel.Description,
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
    }
}
