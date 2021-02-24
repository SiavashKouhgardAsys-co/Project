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
    public class HomeDirectionController : Controller
    {
        private readonly IHomeDirectionService _homeDirectionService;
        public HomeDirectionController(IHomeDirectionService homeDirectionService)
        {
            _homeDirectionService = homeDirectionService;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<HomeDirection>> sendDataToView = new SendDataToView<IQueryable<HomeDirection>>();
            var data= _homeDirectionService.GetAllHomeDirection();
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(HomeDirection homeDirection)
        {
            var result = await _homeDirectionService.CreateHomeDirection(homeDirection);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));

        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _homeDirectionService.GetHomeDirectionById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(HomeDirection homeDirection)
        {
            var result = await _homeDirectionService.DeleteHomeDirection(homeDirection.Id);
            return RedirectToAction("Inddex", new RouteValueDictionary(new { resultStatus = result.StatusResult })); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _homeDirectionService.GetHomeDirectionById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeDirection homeDirection)
        {
            var data = await _homeDirectionService.EditHomeDirection(homeDirection);
            return RedirectToAction("Index" , new RouteValueDictionary(new { resultStatus = data.StatusResult }));
        }
    }
}
