using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MoshaverAmlak.Areas.User.Controllers
{
    [Area("User")]
    public class ZoneController : Controller
    {
        [HttpGet()]
        // SHOW ALL FILES
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        // ADD NEW FILE
        public IActionResult Create() => View();
    }
}
