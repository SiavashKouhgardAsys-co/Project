using Microsoft.AspNetCore.Mvc;
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
       

        [HttpGet]
        public IActionResult Detail() => View();
        [HttpGet]
        public IActionResult Delete() => View();
        [HttpGet]
        public IActionResult Edit() => View();
    }
}
