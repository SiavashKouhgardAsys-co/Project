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
    public class TypeOfDocumentController : Controller
    {
        private readonly ITypeOfDocumentService _typeOfDocumentService;
        public TypeOfDocumentController(ITypeOfDocumentService typeOfDocumentService)
        {
            _typeOfDocumentService = typeOfDocumentService;
        }
        
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<IQueryable<TypeOfDocument>> sendDataToView = new SendDataToView<IQueryable<TypeOfDocument>>();
            var documents = _typeOfDocumentService.GetAllTypeOfDocument();
            if (documents.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            sendDataToView.Entity = documents.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TypeOfDocument typeOfDocument)
        {
            var result = await _typeOfDocumentService.CreateTypeOfDocument(typeOfDocument);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _typeOfDocumentService.GetTypeOfDocumentById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TypeOfDocument typeOfDocument)
        {
            var result = await _typeOfDocumentService.DeleteTypeOfDocument(typeOfDocument.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _typeOfDocumentService.GetTypeOfDocumentById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(TypeOfDocument typeOfDocument)
        {
            var result = await _typeOfDocumentService.EditTypeOfDocument(typeOfDocument);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }
    }
}
