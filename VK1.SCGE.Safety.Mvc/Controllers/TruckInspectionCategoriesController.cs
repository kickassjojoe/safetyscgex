using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {

    [Authorize]
    public class TruckInspectionCategoriesController : Controller {
        private readonly App app;

        public TruckInspectionCategoriesController(App app) {
            this.app = app;
        }

        public async Task<IActionResult> Index(string sms) {
            ViewBag.ActiveMenu = "Master";
            TempData["Msg"] = sms;

            ViewBag.Categories = await app.TruckInspectionCategories.AllAsyncAsNoTracking();

            return View();
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TruckInspectionCategory item) {
            try {
                if (ModelState.IsValid) {
                    item.CreatedBy = User.Identity.Name;
                    await app.TruckInspectionCategories.AddAsync(item);
                    await app.SaveChangesAsync();

                    return RedirectToAction(nameof(TruckInspectionCategoriesController.Index), new { sms = "Successfully" });
                }
            } catch (Exception ex) {

                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(TruckInspectionCategoriesController.Index), new { sms = message });
                throw;
            }

            return View();
        }

        public async Task<IActionResult> Delete(int id) {
            try {
                var item = await app.TruckInspectionCategories.FindAsync(id);
                if (item == null) {
                    return RedirectToAction(nameof(TruckInspectionCategoriesController.Index), new { sms = "Item not found." });
                }

                await app.TruckInspectionCategories.RemoveAsync(item);

                await app.SaveChangesAsync();

                return RedirectToAction(nameof(TruckInspectionCategoriesController.Index), new { sms = "Deleted" });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(TruckInspectionCategoriesController.Index), new { sms = message });
            }

        }
    }
}
