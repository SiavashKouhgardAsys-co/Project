using Microsoft.AspNetCore.Mvc;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System.Linq;

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

        //public IActionResult Index(string resultStatus)
        //{
        //    SendDataToView<IQueryable<CategoryFacilities>> data = new SendDataToView<IQueryable<CategoryFacilities>>();
        //    data.Entity = _categoryFacilitiesService.GetAllCategoryFacilities();
        //    if (resultStatus != null)
        //        data.Message = Result.GetMessage(resultStatus);
        //    return View(data);
        //}

        [HttpGet]
        public IActionResult Create() => View();


        [HttpGet]
        public IActionResult Delete() => View();

        [HttpGet]
        public IActionResult Edit() => View();
    }
}
