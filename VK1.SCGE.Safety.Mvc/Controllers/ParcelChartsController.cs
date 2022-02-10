using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    public class ParcelChartsController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Chart() {
            return View();
        }
    }
}
