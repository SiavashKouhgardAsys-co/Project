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
    public class HomeDirectionController : Controller
    {
        private readonly IHomeDirectionService _homeDirectionService;
        public HomeDirectionController(IHomeDirectionService homeDirectionService)
        {
            _homeDirectionService = homeDirectionService;
        }
        public IActionResult Index()
        {
            var data = _homeDirectionService.GetAllHomeDirection();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(HomeDirection homeDirection)
        {
            var result = await _homeDirectionService.CreateHomeDirection(homeDirection);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _homeDirectionService.GetHomeDirectionById(id);
            return View(data.Entity);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(HomeDirection homeDirection)
        {
            var data = await _homeDirectionService.DeleteHomeDirection(homeDirection.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _homeDirectionService.GetHomeDirectionById(id);
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeDirection homeDirection)
        {
            var data = await _homeDirectionService.EditHomeDirection(homeDirection);
            return RedirectToAction("Index");
        }
    }
}
