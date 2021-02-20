using Microsoft.AspNetCore.Mvc;
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
    public class HomeFileTypeController : Controller
    {
        private readonly IHomeFileTypeService _homeFileType;
        public HomeFileTypeController(IHomeFileTypeService homeFileType)
        {
            _homeFileType = homeFileType;
        }
        public IActionResult Index()
        {
            var data = _homeFileType.GetAllHomeFileType();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(HomeFileType homeFileType)
        {
            var result = await _homeFileType.CreateHomeFileType(homeFileType);
            return RedirectToAction("Index");
        }

        [HttpGet]   
        public IActionResult Delete(int id)
        {
            var data = _homeFileType.GetHomeFileTypeById(id);

            return View(data.Entity);
        }
        
        [HttpPost] 
        public async Task<IActionResult> Delete(HomeFileType homeFileType)
        {
            var result = await _homeFileType.DeleteHomeFileType(homeFileType.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _homeFileType.GetHomeFileTypeById(id);
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeFileType homeFileType)
        {
            var data = await _homeFileType.EditHomeFileType(homeFileType);
            return RedirectToAction("Index");
        }
         
    }
}
