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
    public class RebuiltController : Controller
    {
        private readonly IRebuiltService _rebuilt;
        public RebuiltController(IRebuiltService rebuilt)
        {
            _rebuilt = rebuilt;
        }


        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<Rebuilt>> data = new SendDataToView<IQueryable<Rebuilt>>();
            var rebuilt = _rebuilt.GetAllRebuilt();
            if (rebuilt.Result.StatusResult != (int)Result.Status.OK) return NoContent();
            data.Entity = rebuilt.Entity;
            if (resultStatus != null)
                data.Message = Result.GetMessage(resultStatus);
            return View(data);
        }
            


        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Rebuilt rebuilt)
        {
            var resultRebuilt = await _rebuilt.CreateRebuilt(rebuilt);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = resultRebuilt.StatusResult }));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var rebuilt = _rebuilt.GetRebuiltById(id);
            if (rebuilt.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = rebuilt.Result.StatusResult }));
            return View(rebuilt.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Rebuilt rebuilt)
        {
            var result = await _rebuilt.DeleteRebuilt(rebuilt.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rebuilt = _rebuilt.GetRebuiltById(id);
            if (rebuilt.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = rebuilt.Result.StatusResult }));
            return View(rebuilt.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Rebuilt rebuilt)
        {
            var result = await _rebuilt.EditRebuilt(rebuilt);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }



    }
}
