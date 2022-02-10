using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Authorize]
    public class BranchesController : Controller {
        private readonly App app;

        public BranchesController(App app) {
            this.app = app;
        }

        public async Task<List<Region>> Regions() => (await app.Regions.AllAsyncAsNoTracking()).ToList();

        public async Task<IActionResult> Index(string sms) {
            ViewBag.ActiveMenu = "Master";
            TempData["Msg"] = sms;

            ViewBag.Branches = await app.Branches.AllAsync();

            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name");

            return View();
        }

        public async Task<IActionResult> Edit(string id) {
            var model = await app.Branches.FindAsync(id);
            if (model == null) return RedirectToAction(nameof(Index), new { sms = "Data not found." });

            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name",model.RegionId);

            ViewBag.Branches = (await app.Branches.AllAsync()).ToList();

            return View(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Branch item, string branchCode) {
            try {
                if (ModelState.IsValid) {
                    item.Modified = DateTime.Now;
                    item.ModifiedBy = User.Identity.Name;

                    await app.Branches.UpdateAsync(item);
                    await app.SaveChangesAsync();

                    return RedirectToAction(nameof(Index), new { sms = "Successfully" });
                }

            } catch (DBConcurrencyException) {
                bool itemExits = await ItemExists(branchCode);
                if (!itemExits) {
                    return RedirectToAction(nameof(Index), new { sms = "Data not found." });
                }
            }

            return View();
        }

        private async Task<bool> ItemExists(string branchCode) {
            var result = await app.Branches.FindAsync(branchCode);
            if (result == null) return false;
            return true;
        }

        public async Task<IActionResult> Create() {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Branch item) {
            try {
                if (ModelState.IsValid) {
                    item.CreatedBy = User.Identity.Name;
                    await app.Branches.AddAsync(item);
                    await app.SaveChangesAsync();

                    return RedirectToAction(nameof(Index), new { sms = "Successfully" });

                } else {
                    string message = String.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                    return RedirectToAction(nameof(Index), new { sms = message });

                }

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new { sms = message });
            }

        }

        public async Task<IActionResult> Delete(string id) {
            try {
                var item = await app.Branches.FindAsync(id);
                if (item == null) {
                    return RedirectToAction(nameof(Index), new { sms = "Item not found." });
                }

                await app.Branches.RemoveAsync(item);

                await app.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { sms = "Deleted" });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }

        }
    }
}
