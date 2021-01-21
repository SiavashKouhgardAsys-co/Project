using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MoshaverAmlak.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagedRoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
