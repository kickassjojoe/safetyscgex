using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Mvc.Models;
using VK1.SCGE.Safety.Mvc.Data;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers.Reports {

    [Authorize]
    public class InvestigateReportsController : Controller {
        private readonly App app;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;

        public InvestigateReportsController(App app, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager) {
            this.app = app;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
        }

        public async Task<string> GetRoleName() {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var role = await userManager.GetRolesAsync(user);

            return role[0].ToString();

        }

        // public async Task<ApplicationRol>

        public async Task<IActionResult> Index() {
            var branches = await app.Branches.AllAsyncAsNoTracking();
            ViewBag.Branches = new SelectList(branches.Select(x => new { Id = x.BranchCode, Name = x.BranchCode }), "Id", "Name");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInvestigates(string branchCode) {
            ViewBag.BranchCode = branchCode;

            string[] statuses = new string[] { "200", "300" };

            //var model = (await app.InvestigateCards.QueryAsync(x => x.InvestigateStatusCode == "200")).ToList();

            var model = (await app.InvestigateCards.QueryAsync(x => statuses.Contains(x.InvestigateStatusCode))).ToList();

            model = branchCode != null ? model.Where(x => x.PartOne.BranchCode == branchCode).ToList() : model.ToList();

            ViewBag.RoleName = await GetRoleName();

            return PartialView("pv_Table", model);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAsPdf(Guid id) {
            try {

                var model = await app.InvestigateCards.FindAsync(id);

                for (int i = 1; i < 5; i++) {
                    var imgFolder = Path.Combine(webHostEnvironment.WebRootPath, "resources", "images");
                    var fileName = $"{id}_{i}.png";
                    string filePath = Path.Combine(imgFolder, fileName);
                    if (System.IO.File.Exists(filePath)) {
                        byte[] imageByteData = System.IO.File.ReadAllBytes(filePath);
                        string imageBase64Data = Convert.ToBase64String(imageByteData);
                        string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        ViewData[$"Image{i}"] = imageDataURL;
                    }
                }

                var unsafeActTranDict = new Dictionary<string, List<string>>();
                var unsafeActDepotDict = new Dictionary<string, List<string>>();
                var unsafeConTranDict = new Dictionary<string, List<string>>();
                var unsafeConDepotDict = new Dictionary<string, List<string>>();

                string[] arrUnsafeCodes = model.PartFive.PartFiveDetails.Select(x => x.UnsafeCategoryCode).Distinct().ToArray();

                for (int i = 0; i < arrUnsafeCodes.Length; i++) {
                    var key = await app.UnsafeCategories.FindAsync(arrUnsafeCodes[i]);
                    var value = model.PartFive.PartFiveDetails.Where(x => x.UnsafeCategoryCode == key.UnsafeCategoryCode);

                    switch (arrUnsafeCodes[i]) {
                        case "100":
                        case "200":
                        case "300":
                        case "400":
                            unsafeActTranDict.Add(key.Name, value.Select(
                                x => x.UnsafeItemCode == "311" || x.UnsafeItemCode == "216" ? x.Description : x.UnsafeItem.Name).ToList());
                            break;
                        case "500":
                        case "600":
                        case "700":
                            unsafeActDepotDict.Add(key.Name, value.Select(
                                x => x.UnsafeItemCode == "619" ? x.Description : x.UnsafeItem.Name).ToList());
                            break;
                        case "800":
                            unsafeConTranDict.Add(key.Name, value.Select(
                                x => x.UnsafeItemCode == "813" ? x.Description : x.UnsafeItem.Name).ToList());
                            break;
                        case "900":
                            unsafeConDepotDict.Add(key.Name, value.Select(
                                x => x.UnsafeItemCode == "915" ? x.Description : x.UnsafeItem.Name).ToList());
                            break;
                        default:
                            break;
                    }


                }

                ViewData["UnsafeActTranDict"] = unsafeActTranDict;
                ViewData["UnsafeActDepotDict"] = unsafeActDepotDict;
                ViewData["UnsafeConTranDict"] = unsafeConTranDict;
                ViewData["UnsafeConDepotDict"] = unsafeConDepotDict;

                return new ViewAsPdf("ViewAsPdf", model, ViewData) {
                    CustomSwitches = "--footer-center \"  Created Date: " +
                                          DateTime.Now.Date.ToString("dd/MM/yyyy") +
                                          "  Page: [page]/[toPage]\"" +
                                          " --disable-smart-shrinking" +
                                          " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"",
                    PageMargins = { Left = 15, Bottom = 10, Right = 10, Top = 10 },
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageSize = Rotativa.AspNetCore.Options.Size.A4
                };

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }
        }

        public IActionResult DisplayImage(Guid investigateCardId, int order) {
            string fileName = $"{investigateCardId}_{order}";

            var imgFolder = Path.Combine(webHostEnvironment.WebRootPath, "resources", "images");
            string filePath = Path.Combine(imgFolder, fileName);
            byte[] imageByteData = System.IO.File.ReadAllBytes(filePath);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);

            ViewData["ImageData"] = imageDataURL;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Approve(string id) {
            try {
                Guid _id = new Guid(id);
                var item = await app.InvestigateCards.FindAsync(_id);

                if (item == null) {
                    var _result = new {
                        Message = "ItemNotFound",
                        Error = ""
                    };
                    return Json(_result);
                }

                item.SetApprove(User.Identity.Name);
                await app.SaveChangesAsync();
                var result = new {
                    Message = "Successfully",
                    Error = ""
                };

                return Json(result);

            } catch (Exception ex) {
                string error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                var result = new {
                    Message = "Errors",
                    Error = error
                };

                return Json(result);

            }
        }

    }
}
