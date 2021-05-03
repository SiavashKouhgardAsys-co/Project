using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.User.Controllers
{
    [Area("User")]
    public class HomeFileController : Controller
    {
        private readonly IHomeFileService _homeFileService;
        public HomeFileController(IHomeFileService homeFileService)
        {
            _homeFileService = homeFileService;
        }

        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<HomeFile>> sendDataToView = new SendDataToView<IQueryable<HomeFile>>();
            var data = _homeFileService.GetAllHomeFile();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = data.Entity;
            if (sendDataToView != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }


        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(HomeFile homeFile)
        {
            var result = await _homeFileService.CreateHomeFile(homeFile);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var data = _homeFileService.GetHomeFileById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));

            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _homeFileService.GetHomeFileById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(HomeFile homeFile)
        {
            var result = await _homeFileService.DeleteHomeFile(homeFile.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _homeFileService.GetHomeFileById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));

            return View(data.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HomeFile homeFile)
        {
            var result = await _homeFileService.EditHomeFile(homeFile);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

    }
}
