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
    public class FileTypeController : Controller
    {
        private readonly IFileTypeService _fileTypeService;
        public FileTypeController(IFileTypeService fileTypeService)
        {
            _fileTypeService = fileTypeService;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<FileType>> sendDataToView = new SendDataToView<IQueryable<FileType>>();
            var data = _fileTypeService.GetAllFileTypes();
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(FileType fileType)
        {
            var result = await _fileTypeService.CreateFileType(fileType);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _fileTypeService.GetFileTypeById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FileType fileType)
        {
            var result = await _fileTypeService.DeleteFileType(fileType.Id);
            return RedirectToAction("Index" , new RouteValueDictionary(new { resultStatus = result.StatusResult }));

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _fileTypeService.GetFileTypeById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FileType fileType)
        {
            var result = await _fileTypeService.EditFileType(fileType);
            return RedirectToAction("Index" , new RouteValueDictionary(new { resultStatus = result.StatusResult}));
            
        }
    }
}
