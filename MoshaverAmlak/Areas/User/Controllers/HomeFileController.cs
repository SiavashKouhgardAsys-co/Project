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

namespace MoshaverAmlak.Areas.User.Controllers
{
    [Area("User")]
    public class HomeFileController : Controller
    {
        private readonly IHomeFileService _homeFileService;
        private readonly IProvinceService _provinceService;
        private readonly ICityService _cityService;
        private readonly IFacilitiesService _facilitiesService;
        private readonly IRegionService _regionService;
        private readonly IRebuiltService _rebuiltService;
        private readonly ICategoryFacilitiesService _categoryFacilitiesService;
        private readonly INeighbourhoodService _neighbourhoodService;
        private readonly IFileTypeService _fileTypeService;
        private readonly IHomeFileTypeService _homefileTypeService;
        private readonly IHomeDirectionService _homeDirectionService;
        private readonly ITypeOfDocumentService _typeOfDocumentService;
        public HomeFileController(IHomeFileService homeFileService , IProvinceService provinceService , ICityService cityService , IFacilitiesService facilitiesService , IRegionService regionService , IRebuiltService rebuiltService , ICategoryFacilitiesService categoryFacilitiesService , INeighbourhoodService neighbourhoodService , IFileTypeService fileTypeService , IHomeDirectionService homeDirectionService , IHomeFileTypeService homeFileTypeService , ITypeOfDocumentService typeOfDocumentService)
        {
            _homeFileService = homeFileService;
            _provinceService = provinceService;
            _cityService = cityService;
            _categoryFacilitiesService = categoryFacilitiesService;
            _facilitiesService = facilitiesService;
            _homeDirectionService = homeDirectionService;
            _homefileTypeService = homeFileTypeService;
            _neighbourhoodService = neighbourhoodService;
            _rebuiltService = rebuiltService;
            _regionService = regionService;
            _rebuiltService = rebuiltService;
            _fileTypeService = fileTypeService;
            _typeOfDocumentService = typeOfDocumentService;
        }

        public IActionResult Index(string resultStatus)
        {
            SendDataToView<List<HomeFileViewmodel>> sendDataToView = new SendDataToView<List<HomeFileViewmodel>>();
            var data = _homeFileService.GetAllHomeFiles();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = data.Entity;
            if (sendDataToView != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }


        [HttpGet]
        public IActionResult Create()
        {
            HomeFileCreateViewmodel homeFileCreateViewmodel = new HomeFileCreateViewmodel();
            
            var regions = _regionService.GetAllRegions();
            if(regions.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = regions.Result.StatusResult }));
            homeFileCreateViewmodel.Region = regions.Entity;

            var typeOfDocument = _typeOfDocumentService.GetAllTypeOfDocument();
            if (typeOfDocument.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = typeOfDocument.Result.StatusResult }));
            homeFileCreateViewmodel.TypeOfDocuments = typeOfDocument.Entity;

            var homeDirections = _homeDirectionService.GetAllHomeDirection();
            if (homeDirections.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = homeDirections.Result.StatusResult }));
            homeFileCreateViewmodel.HomeDirections = homeDirections.Entity;

            var neighbours = _neighbourhoodService.GetAllNeighbourhood();
            if (neighbours.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = neighbours.Result.StatusResult }));
            homeFileCreateViewmodel.Neighbourhoods = neighbours.Entity;

            var rebuilts = _rebuiltService.GetAllRebuilt();
            if (rebuilts.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = rebuilts.Result.StatusResult }));
            homeFileCreateViewmodel.Rebuilts = rebuilts.Entity;

            var fileTypes = _fileTypeService.GetAllFileTypes();
            if (fileTypes.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = fileTypes.Result.StatusResult }));
            homeFileCreateViewmodel.FileTypes = fileTypes.Entity;

            var homeFileTypes = _homefileTypeService.GetAllHomeFileType();
            if (homeFileTypes.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = homeFileTypes.Result.StatusResult }));
            homeFileCreateViewmodel.HomeFileTypes = homeFileTypes.Entity;


            return View(homeFileCreateViewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HomeFileViewmodel homeFileViewmodel)
        {
            var result = await _homeFileService.CreateHomeFile(new HomeFile() 
            {
                //yes please...
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var data = _homeFileService.GetHomeFileById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));

            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _homeFileService.GetHomeFileById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(HomeFile homeFile)
        {
            var result = await _homeFileService.DeleteHomeFile(homeFile.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _homeFileService.GetHomeFileById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));

            return View(data.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HomeFile homeFile)
        {
            var result = await _homeFileService.EditHomeFile(homeFile);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

    }
}
