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
    public class HomeFileTypeController : Controller
    {
        private readonly IHomeFileTypeService _homeFileType;
        public HomeFileTypeController(IHomeFileTypeService homeFileType)
        {
            _homeFileType = homeFileType;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<HomeFileType>> sendDataToView = new SendDataToView<IQueryable<HomeFileType>>();
            var data = _homeFileType.GetAllHomeFileType();
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(HomeFileType homeFileType)
        {
            var result = await _homeFileType.CreateHomeFileType(homeFileType);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]   
        public IActionResult Delete(int id)
        {
            var data = _homeFileType.GetHomeFileTypeById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }
        
        [HttpPost] 
        public async Task<IActionResult> Delete(HomeFileType homeFileType)
        {
            var result = await _homeFileType.DeleteHomeFileType(homeFileType.Id);
            return RedirectToAction("Index" , new RouteValueDictionary (new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _homeFileType.GetHomeFileTypeById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeFileType homeFileType)
        {
            var data = await _homeFileType.EditHomeFileType(homeFileType);
            return RedirectToAction("Index" , new RouteValueDictionary(new { resultStatus = data.StatusResult }));
        }
         
    }
}
