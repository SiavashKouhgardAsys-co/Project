using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IProvinceService _provinceService;

        public CityController(ICityService cityService, IProvinceService provinceService)
        {
            _cityService = cityService;
            _provinceService = provinceService;
        }

        public IActionResult Index(string resultStatus)
        {
            SendDataToView<List<CityViewmodel>> data = new SendDataToView<List<CityViewmodel>>();
            var cities = _cityService.GetAllCities();
            if (cities.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            data.Entity = cities.Entity;
            if (string.IsNullOrEmpty(resultStatus))
                data.Message = Result.GetMessage(resultStatus);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CityViewmodel_Create cityViewmodel = new CityViewmodel_Create();
            var province = _provinceService.GetAllProvinces();
            if (province.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = province.Result.StatusResult }));
            cityViewmodel.Provinces = province.Entity;
            return View(cityViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            var result = await _cityService.CreateCity(city);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var city = _cityService.GetCityById(id);
            if (city.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = city.Result.StatusResult }));
            return View(city.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CityViewmodel cityViewmodel)
        {
            var result = await _cityService.DeleteCity(cityViewmodel.CityId);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CityViewmodel_Edit cityViewmodel = new CityViewmodel_Edit();
            var city = _cityService.GetCityById(id);
            if (city.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = city.Result.StatusResult }));
            cityViewmodel.City = city.Entity;
            var province = _provinceService.GetAllProvinces();
            if (province.Result.StatusResult != (int)Result.Status.OK) RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = province.Result.StatusResult }));
            cityViewmodel.Provinces = province.Entity;
            return View(cityViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CityViewmodel_Edit cityViewmodelEdit)
        {
            var result = await _cityService.EditCity(cityViewmodelEdit.City);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
    }
}
