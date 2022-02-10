using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Authorize]
    public class PenaltyNoticesController : Controller {
        private readonly App app;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PenaltyNoticesController(App app, IWebHostEnvironment webHostEnvironment) {
            this.app = app;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string sms) {
            var branches = await app.Branches.AllAsyncAsNoTracking();
            ViewBag.Branches = new SelectList(branches.Select(x => new { Id = x.BranchCode,Name=x.BranchCode }), "Id", "Name");

            TempData["Msg"] = sms;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPenalties(string branchCode) {

            var model = (await app.PenaltyNotices.AllAsync()).ToList();

            model = branchCode != null ? model.Where(x => x.BranchCode == branchCode).ToList() : model.ToList();

            return PartialView("pv_Table", model);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAsPdf(string id) {
            try {

                var model = await app.PenaltyNotices.FindAsync(id);
                var totalDeduct = (await app.PenaltyNotices.QueryAsyncAsNoTracking(x => x.PenaltyNoticeCode == id && x.CreatedDate.Year == DateTime.Now.Year)).ToList().Sum(x => x.TotalDeductPoint);

                ViewData["TotalDeduct"] = totalDeduct;

                var imgFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(imgFolder, "logo.png");
                byte[] imageByteData = System.IO.File.ReadAllBytes(filePath);
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);

                ViewData["ImageData"] = imageDataURL;

                return new ViewAsPdf("ViewAsPdf", model, ViewData) {
                    CustomSwitches = "--footer-center \"  Created Date: " +
                                          DateTime.Now.Date.ToString("dd/MM/yyyy") +
                                          "  Page: [page]/[toPage]\"" +
                                          " --disable-smart-shrinking" +
                                          " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"",
                    PageMargins = { Left = 25, Bottom = 10, Right = 15, Top = 10 },
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.A4
                };

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }
        }

        public IActionResult DisplayImage() {
            var imgFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(imgFolder, "logo.png");
            byte[] imageByteData = System.IO.File.ReadAllBytes(filePath);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);

            ViewData["ImageData"] = imageDataURL;

            return View();
        }
    }
}
