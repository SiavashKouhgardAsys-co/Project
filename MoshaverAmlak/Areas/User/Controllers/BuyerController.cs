using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.User.Controllers
{
    [Area("User")]
    public class BuyerController : Controller
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
