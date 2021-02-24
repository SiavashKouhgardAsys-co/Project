using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<Region>> data = new SendDataToView<IQueryable<Region>>();
            var region = _regionService.GetAllRegions();
            if (region.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            data.Entity = region.Entity;
            if (resultStatus != null)
                data.Message = Result.GetMessage(resultStatus);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Region region)
        {
            var resultRegion = await _regionService.CreateRegion(region);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = resultRegion.StatusResult }));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var region = _regionService.GetRegionById(id);
            if (region.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = region.Result.StatusResult}));
            return View(region.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Region region)
        {
            var result = await _regionService.DeleteRegion(region.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var region = _regionService.GetRegionById(id);
            if (region.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("index", new RouteValueDictionary(new { statusResult = region.Result.StatusResult }));
            return View(region.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Region region)
        {
            var result = await _regionService.EditRegion(region);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

    }
}
