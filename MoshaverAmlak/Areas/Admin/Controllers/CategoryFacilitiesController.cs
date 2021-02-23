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
    public class CategoryFacilitiesController : Controller
    {
        private readonly ICategoryFacilitiesService _categoryFacilitiesService;
        public CategoryFacilitiesController(ICategoryFacilitiesService categoryFacilities)
        {
            _categoryFacilitiesService = categoryFacilities;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<CategoryFacilities>> data = new SendDataToView<IQueryable<CategoryFacilities>>();
            var category = _categoryFacilitiesService.GetAllCategoryFacilities();
            if (category.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            data.Entity = category.Entity;
            if (resultStatus != null)
                data.Message = Result.GetMessage(resultStatus);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CategoryFacilities category)
        {
            var resultCategory = await _categoryFacilitiesService.CreateCategoryFacilities(category);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = resultCategory.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete() => View();

        [HttpGet]
        public IActionResult Edit() => View();
    }
}
