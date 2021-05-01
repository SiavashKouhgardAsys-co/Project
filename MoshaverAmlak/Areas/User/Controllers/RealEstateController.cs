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
    public class RealEstateController : Controller
    {
        private readonly IRealStateService _realStateService;
        public RealEstateController(IRealStateService realStateService)
        {
            _realStateService = realStateService;

        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<List<RealStateViewmodel>> sendDataToView = new SendDataToView<List<RealStateViewmodel>>();
            
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var data = _realStateService.GetAllRealStates(userId);
            
            sendDataToView.Entity = data.Entity;
            if(resultStatus == null)
                sendDataToView.Message = Result.GetMessage(resultStatus);

            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(RealStateViewmodel realStateViewmodel) 
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _realStateService.CreateRealState(new RealEstate()
            {
                UserId = userId,
                Id = realStateViewmodel.Id,
                Name = realStateViewmodel.Name,
                RegistrationNumber = realStateViewmodel.RegistrationNumber,
                Description = realStateViewmodel.Description
            });

            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _realStateService.GetRealStateById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(RealEstate realEstate)
        {
            var result = await _realStateService.DeleteRealState(realEstate.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _realStateService.GetRealStateById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));

            RealStateViewmodel realStateViewmodel = new RealStateViewmodel()
            {
                Id = data.Entity.Id,
                Name = data.Entity.Name,
                RegistrationNumber = data.Entity.RegistrationNumber,
                Description = data.Entity.Description
            };
            return View(realStateViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RealStateViewmodel realStateViewmodel)
        {
            var result = await _realStateService.EditRealState(new RealEstate()
            {
                Id = realStateViewmodel.Id,
                Name = realStateViewmodel.Name,
                Description = realStateViewmodel.Description,
                RegistrationNumber = realStateViewmodel.RegistrationNumber
            });

            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }


        [HttpGet]
        public IActionResult CreateRealStateTel(int realStateId, string statusResult = null)
        {
            SendDataToView<List<RealStateTelViewmodel>> sendDataToView = new SendDataToView<List<RealStateTelViewmodel>>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _realStateService.GetRealStateById(realStateId, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            var tels = _realStateService.GetAllRealStateTelByUserId(realStateId);
            if (tels.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = tels.Result.StatusResult }));
            RealStateTelViewmodel realStateTelViewmodel = new RealStateTelViewmodel()
            {
                RealState = data.Entity,
                Tels = tels.Entity,
                RealStateInfo = new RealEstateTel()
            };
            if (statusResult != null)
                sendDataToView.Message = Result.GetMessage(statusResult);
            return View(realStateTelViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRealStateTel(RealStateTelViewmodel realStateTelViewmodel)
        {
            var result = await _realStateService.CreateRealStateTel(new RealEstateTel()
            {
                RealEstateId = realStateTelViewmodel.RealStateInfo.RealEstateId,
                Tel = realStateTelViewmodel.RealStateInfo.Tel
            });
            return RedirectToAction("CreateRealStateTel", new RouteValueDictionary(new { resultStatus = result.StatusResult, realStateId = realStateTelViewmodel.RealStateInfo.RealEstateId }));

        }

        [HttpGet]
        public async Task<IActionResult> DeleteRealStateTel(string telId, string realStateId)
        {
            var result = await _realStateService.DeleteRealStateTel(int.Parse(telId));
            return RedirectToAction("CreateRealStateTel", new RouteValueDictionary(new { realStateId = realStateId, resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult CreateRealStateAddress(int realStateId, string statusResult = null)
        {
            SendDataToView<List<RealStateAddressViewmodel>> sendDataToView = new SendDataToView<List<RealStateAddressViewmodel>>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _realStateService.GetRealStateById(realStateId, userId);

            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));

            var addresses = _realStateService.GetAllRealStateAddressByUserId(realStateId);
            if (addresses.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = addresses.Result.StatusResult }));

            RealStateAddressViewmodel realStateAddressViewmodel = new RealStateAddressViewmodel()
            {
                RealState = data.Entity,
                Addresses = addresses.Entity,
                AddressInfo = new RealEstateAddress()
            };
            if (statusResult != null)
                sendDataToView.Message = Result.GetMessage(statusResult);
            return View(realStateAddressViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRealStateAddress(RealStateAddressViewmodel realStateAddressViewmodel)
        {
            var result = await _realStateService.CreateRealStateAddress(new RealEstateAddress()
            {
                RealEstateId = realStateAddressViewmodel.AddressInfo.RealEstateId,
                Address = realStateAddressViewmodel.AddressInfo.Address
            });
            return RedirectToAction("CreateRealStateAddress", new RouteValueDictionary(new { resultStatus = result.StatusResult, realStateId = realStateAddressViewmodel.AddressInfo.RealEstateId }));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRealStateAddress(string addressId , string realStateId)
        {
            var result = await _realStateService.DeleteRealStateAddress(int.Parse(addressId));
            return RedirectToAction("CreateRealStateAddress", new RouteValueDictionary(new { realStateId = realStateId, resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _realStateService.GetRealStateForDetails(id, userId);
            //if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }
    }
}
