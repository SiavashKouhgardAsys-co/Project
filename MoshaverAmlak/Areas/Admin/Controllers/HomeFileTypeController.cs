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
        private readonly IHomeFileTypeService _homeFileTypeService;
        public HomeFileTypeController(IHomeFileTypeService homeFileTypeService)
        {
            _homeFileTypeService = homeFileTypeService;
        }
        public IActionResult Index()
        {
            var data = _homeFileTypeService.GetAllHomeFileType();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(HomeFileType homeFileType)
        {
            var result = await _homeFileTypeService.CreateHomeFileType(homeFileType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _homeFileTypeService.GetHomeFileTypeById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            return View(data.Entity);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(HomeFileType homeFileType)
        {
            var result = await _homeFileTypeService.DeleteHomeFileType(homeFileType.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _homeFileTypeService.GetHomeFileTypeById(id);
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeFileType homeFileType)
        {
            var data = await _homeFileTypeService.EditHomeFileType(homeFileType);
            return RedirectToAction("Index");
        }
         
    }
}
