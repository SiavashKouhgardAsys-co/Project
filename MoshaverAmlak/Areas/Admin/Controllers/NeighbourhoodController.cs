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
    public class NeighbourhoodController : Controller
    {
        private readonly INeighbourhoodService _neighbourhood;
        public NeighbourhoodController(INeighbourhoodService neighbourhood)
        {
            _neighbourhood = neighbourhood;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<Neighbourhood>> sendDataToView = new SendDataToView<IQueryable<Neighbourhood>>();
            var data = _neighbourhood.GetAllNeighbourhood();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);

        }


        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Neighbourhood neighbourhood)
        {
            var result = await _neighbourhood.CreateNeighbourhood(neighbourhood);
            return RedirectToAction("Index" , new RouteValueDictionary(new {resultStatus = result.StatusResult }));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _neighbourhood.GetNeighbourhoodById(id);
            return View(data.Entity);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Neighbourhood neighbourhood)
        {
            var data = await _neighbourhood.DeleteNeighbourhoodById(neighbourhood.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _neighbourhood.GetNeighbourhoodById(id);
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Neighbourhood neighbourhood)
        {
            var data = await _neighbourhood.EditNeighbourhood(neighbourhood);
            return RedirectToAction("Index");
        }
    }
}
