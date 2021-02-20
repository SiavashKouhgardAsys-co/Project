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
    public class FacilitiesController : Controller
    {
        private readonly IFacilitiesService _facilities;
        public FacilitiesController(IFacilitiesService facilities)
        {
            _facilities = facilities;
        }
        public IActionResult Index()
        {
            var data = _facilities.GetAllFacilities();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Facilities facilities)
        {
            var result = await _facilities.CreateFacilities(facilities);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _facilities.GetFacilitiesById(id);
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Facilities facilities)
        {
            var data = await _facilities.DeleteFacilities(facilities.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _facilities.GetFacilitiesById(id);
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Facilities facilities)
        {
            var data = await _facilities.EditFacilities(facilities);
            return RedirectToAction("Index");
        }
    }
}
