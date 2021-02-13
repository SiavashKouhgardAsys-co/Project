using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpGet]
        public IActionResult Delete() => View();

        [HttpGet]
        public IActionResult Edit() => View();

    }
}
