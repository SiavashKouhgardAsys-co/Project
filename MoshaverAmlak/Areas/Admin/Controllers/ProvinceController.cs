using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<Province>> data = new SendDataToView<IQueryable<Province>>();
            var province = _provinceService.GetAllProvinces();
            if (province.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            data.Entity = province.Entity;
            if (string.IsNullOrEmpty(resultStatus))
                data.Message = Result.GetMessage(resultStatus);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Province province)
        {
            var result = await _provinceService.CreateProvince(province);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var province = _provinceService.GetProvinceById(id);
            if (province.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = province.Result.StatusResult }));
            return View(province.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Province province)
        {
            var result = await _provinceService.DeleteProvince(province.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var province = _provinceService.GetProvinceById(id);
            if (province.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = province.Result.StatusResult }));
            return View(province.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Province province)
        {
            var result = await _provinceService.EditProvince(province);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
    }
}
