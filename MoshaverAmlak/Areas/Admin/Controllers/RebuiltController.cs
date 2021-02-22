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
    public class RebuiltController : Controller
    {
        private readonly IRebuiltService _rebuilt;
        public RebuiltController(IRebuiltService rebuilt)
        {
            _rebuilt = rebuilt;
        }


        public IActionResult Index()
        {
            var data = _rebuilt.GetAllRebuilt();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            return View();

        }


        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Rebuilt rebuilt)
        {
            var result = await _rebuilt.CreateRebuilt(rebuilt);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _rebuilt.GetRebuiltById(id);
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Rebuilt rebuilt)
        {
            var data = await _rebuilt.DeleteRebuilt(rebuilt.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _rebuilt.GetRebuiltById(id);
            return View(data.Entity);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Rebuilt rebuilt)
        {
            var data = await _rebuilt.EditRebuilt(rebuilt);
            return RedirectToAction("Index");
        }



    }
}
