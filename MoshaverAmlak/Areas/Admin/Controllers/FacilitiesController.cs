using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FacilitiesController : Controller
    {
        private readonly IFacilitiesService _facilities;
        private readonly ICategoryFacilitiesService _categoryFacilitiesService;
        public FacilitiesController(IFacilitiesService facilities, ICategoryFacilitiesService categoryFacilitiesService)
        {
            _facilities = facilities;
            _categoryFacilitiesService = categoryFacilitiesService;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<List<FacilitiesViewmodel_Entity>> sendDataToView = new SendDataToView<List<FacilitiesViewmodel_Entity>>();
            var data = _facilities.GetAllFacilities();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = data.Entity;
            if (sendDataToView != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var category = _categoryFacilitiesService.GetAllCategoryFacilities();
            if (category.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = category.Result.StatusResult }));
            FacilitiesViewmodel_Create facilitiesViewmodel_Create = new FacilitiesViewmodel_Create();
            facilitiesViewmodel_Create.CategoryFacilities = category.Entity;
            return View(facilitiesViewmodel_Create);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacilitiesViewmodel_Create facilitiesViewmodel_Create)
        {
            var result = await _facilities.CreateFacilities(facilitiesViewmodel_Create.Facilities);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _facilities.GetFacilitiesById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Facilities facilities)
        {
            var result = await _facilities.DeleteFacilities(facilities.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            FacilitiesViewmodel_Edit facilitiesViewmodel = new FacilitiesViewmodel_Edit();
            var data = _facilities.GetFacilitiesById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            facilitiesViewmodel.Facilities = new FacilitiesViewmodel_Entity()
            {
                FacilityId = data.Entity.Id,
                FacilityName = data.Entity.Name,
                CategoryFacilityId = data.Entity.CategoryFacilityId,
            };
            var categoryFacility = _categoryFacilitiesService.GetAllCategoryFacilities();
            if (categoryFacility.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = categoryFacility.Result.StatusResult }));
            facilitiesViewmodel.CategoryFacilities = categoryFacility.Entity;
            return View(facilitiesViewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FacilitiesViewmodel_Edit facilitiesViewmodel)
        {
            Facilities facilities = new Facilities()
            {
                Id = facilitiesViewmodel.Facilities.FacilityId,
                Name = facilitiesViewmodel.Facilities.FacilityName,
                CategoryFacilityId = facilitiesViewmodel.Facilities.CategoryFacilityId
            };
            var result = await _facilities.EditFacilities(facilities);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }


    }
}
