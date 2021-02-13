using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagedUserController : Controller
    {
        [HttpGet()]

        // SHOW ALL USERS
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        // ADD NEW USER
        public IActionResult Register() => View();

        
    }
}
