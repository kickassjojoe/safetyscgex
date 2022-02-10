using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {

    [Authorize]
    public class VehiclesController : Controller {
        private readonly App app;

        public VehiclesController(App app) {
            this.app = app;
        }

        public async Task<List<Branch>> Branches() => (await app.Branches.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Region>> Regions() => (await app.Regions.AllAsyncAsNoTracking()).ToList();

        public async Task<IActionResult> Index(string sms) {
            ViewBag.ActiveMenu = "Master";
            TempData["Msg"] = sms;

            ViewBag.Vehicles = await app.Vehicles.AllAsync();

            ViewBag.Branches = new SelectList((await Branches()).Select(x => new { Id = x.BranchCode, x.Name }), "Id", "Name");

            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name");

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle item) {
            try {
                string regionName = (await app.Regions.FindAsync(item.RegionId)).Name;
                ModelState.Remove("RegionName");
                if (ModelState.IsValid) {
                    item.CreatedBy = User.Identity.Name;
                    item.RegionName = regionName;

                    await app.Vehicles.AddAsync(item);
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

        public async Task<IActionResult> Delete(int id) {
            try {
                var item = await app.Vehicles.FindAsync(id);
                if (item == null) {
                    return RedirectToAction(nameof(Index), new { sms = "Item not found." });
                }

                await app.Vehicles.RemoveAsync(item);

                await app.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { sms = "Deleted" });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }

        }
    }
}
