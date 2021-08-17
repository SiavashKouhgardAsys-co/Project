using Microsoft.AspNetCore.Mvc;
using MoshaverAmlak.Core.Repository.Service.Interface;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
