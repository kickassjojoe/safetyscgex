using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Authorize]
    public class TruckInspectionItemsController : Controller {
        private readonly App app;

        public TruckInspectionItemsController(App app) {
            this.app = app;
        }

        public async Task<IActionResult> Index(string sms) {
            ViewBag.ActiveMenu = "Master";
            TempData["Msg"] = sms;
            var category = (await app.TruckInspectionCategories.AllAsync()).Select(x => new {
                Id = x.TruckInspectionCategoryId,
                x.Name
            }).ToList();

            ViewBag.Category = new SelectList(category, "Id", "Name");
           
            ViewBag.CategoryItems = await app.TruckInspectionItems.AllAsync();

            return View();
        }

        public async Task<IActionResult> Create() {
            ViewBag.ActiveMenu = "Master";
            var category = (await app.TruckInspectionCategories.AllAsync()).Select(x => new {
                Id = x.TruckInspectionCategoryId,
                x.Name
            }).ToList();

            ViewBag.Category = new SelectList(category, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TruckInspectionItem item) {
            try {
                if (ModelState.IsValid) {
                    item.CreatedBy = User.Identity.Name;
                    await app.TruckInspectionItems.AddAsync(item);
                    await app.SaveChangesAsync();

                    return RedirectToAction(nameof(TruckInspectionItemsController.Index), new { sms = "Successfully" });
                }

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(TruckInspectionCategoriesController.Index), new { sms = message });

            }

            return View();
        }

        public async Task<IActionResult> Edit(int id) {
            ViewBag.ActiveMenu = "Master";
            var model = await app.TruckInspectionItems.FindAsync(id);
            if (model == null) {
                return RedirectToAction(nameof(Index), new { sms = "Data nof found," });
            }
            var category = (await app.TruckInspectionCategories.AllAsync()).Select(x => new {
                Id = x.TruckInspectionCategoryId,
                x.Name
            }).ToList();

            ViewBag.Category = new SelectList(category, "Id", "Name",model.TruckInspectionCategoryId);

            ViewBag.CategoryItems = await app.TruckInspectionItems.AllAsync();

            return View(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TruckInspectionItem item, int truckInspectionItemId) {
            try {
                if (ModelState.IsValid) {

                    await app.TruckInspectionItems.UpdateAsync(item);
                    await app.SaveChangesAsync();

                    return RedirectToAction(nameof(Index), new { sms = "Successfully" });
                }
            } catch (DBConcurrencyException) {
                bool itemExits = await ItemExists(truckInspectionItemId);
                if (!itemExits) {
                    return RedirectToAction(nameof(Index), new { sms = "Data not found." });
                }
            }
            return View();
        }

        private async Task<bool> ItemExists(int truckInspectionItemId) {
            var result = await app.TruckInspectionItems.FindAsync(truckInspectionItemId);
            if (result == null) return false;
            return true;
        }

        public async Task<IActionResult> Delete(int id) {
            try {
                var item = await app.TruckInspectionItems.FindAsync(id);
                if (item == null) {
                    return RedirectToAction(nameof(Index), new { sms = "Item not found." });
                }

                await app.TruckInspectionItems.RemoveAsync(item);

                await app.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { sms = "Deleted" });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }

        }

    }
}
