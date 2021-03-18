using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Controllers
{
    public class SewController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Top));
        }

        public IActionResult Top()
        {
            return View();
        }

        public IActionResult Skirt()
        {
            return View();
        }

        public IActionResult Sleeve()
        {
            return View();
        }

        public IActionResult Recommend()
        {
            return View();
        }
    }
}
