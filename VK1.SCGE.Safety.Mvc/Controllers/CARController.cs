using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;
using Rotativa;
using VK1.SCGE.Safety.Mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using VK1.SCGE.Safety.Mvc.Dtos;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Authorize]
    public class CARController : Controller {
        private readonly App app;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CARController(App app, IWebHostEnvironment webHostEnvironment) {
            this.app = app;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.ActiveMenu = "Card";

            ViewBag.Statuses = new SelectList((await app.CARStatuses.AllAsync()).Select(x => new {
                Id = x.CARStatusCode,
                x.Name
            }), "Id", "Name");

            ViewBag.Branches = new SelectList((await app.Branches.AllAsync()).Select(x => new {
                Id = x.BranchCode,
                x.Name
            }), "Id", "Name");

            return View();
        }

        public async Task<IActionResult> GetAll(DateTime dateFrom, DateTime dateTo, string status, string branchCode) {
            try {
                ViewBag.DateFrom = dateFrom;
                ViewBag.DateTo = dateTo;
                ViewBag.BranchCode = branchCode;
                ViewBag.Status = status;

                var model = await app.CAR.QueryAsyncAsNoTracking(x => dateFrom <= x.Created && x.Created <= dateTo);
                model = status != null ? model.Where(x => x.CARStatusCode == status) : model;
                model = branchCode != null ? model.Where(x => x.BranchCode == branchCode) : model;

                ViewBag.Count = model.Count();

                return PartialView("_Table", model);

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewAsPdf(string id) {
            try {
                var data = await app.CAR.FindAsync(id);

                var model = new Dictionary<CorrectiveActionRequest, List<CorrectiveActionRequestItem>>();

                model.Add(data, (await app.CARItem.QueryAsync(x => x.CARCode == data.CARCode)).ToList());

                return new ViewAsPdf("ViewAsPdf", model) {
                    CustomSwitches = "--footer-center \"  Created Date: " +
                                          DateTime.Now.Date.ToString("dd/MM/yyyy") +
                                          "  Page: [page]/[toPage]\"" +
                                          " --disable-smart-shrinking" +
                                          " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"",
                    PageMargins = { Left = 20, Bottom = 30, Right = 20, Top = 10 },
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.A4
                };

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadPdf(CARUploadFileViewModel model) {
            if (ModelState.IsValid) {
                if (model.PdfFile == null ||
                    model.PdfFile.Length == 0 ||
                    model.PdfFile.ContentType != "application/pdf") {
                    var response = new {
                        message = "Error"
                    };

                    return Json(response);
                }

                //save file to wwwroot/pdfs folder
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "pdfs");
                string filePath = Path.Combine(uploadFolder, $"{model.CARCode}.pdf");

                using (var stream = new FileStream(filePath, FileMode.Create)) {
                    await model.PdfFile.CopyToAsync(stream);
                }

                var car = await app.CAR.FindAsync(model.CARCode);
                car.PdfPath = $"~\\wwwroot\\pdfs\\{model.CARCode}.pdf";

                await app.CAR.UpdateAsync(car);
                await app.SaveChangesAsync();

                var result = new {
                    message = new {
                        model.CARCode,
                        model.DateFrom,
                        model.DateTo,
                        branchCode = model.BranchCode ?? "",
                        status = model.Status ?? "",
                    }
                };
                return Json(result);
            }
            return View();
        }

        public async Task<IActionResult> GetPdf(string pdfFile) {
            var file = $"{pdfFile}.pdf";
            var path = Path.Combine(webHostEnvironment.WebRootPath, "pdfs", file);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open)) {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        [HttpGet]
        public IActionResult GetViewModel(string cardCode, DateTime dateFrom, DateTime dateTo, string branchCode, string status) {
            ViewBag.DateFrom = dateFrom;
            ViewBag.DateTo = dateTo;
            ViewBag.BranchCode = branchCode;
            ViewBag.Status = status;

            CARUploadFileViewModel model = new CARUploadFileViewModel {
                CARCode = cardCode,
                PdfFile = null
            };

            return PartialView("_UploadFile", model);
        }


        private string GetContentType(string path) {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes() {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
