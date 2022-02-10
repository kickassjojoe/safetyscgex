using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    public class RegionsController : Controller {
        private readonly App app;

        public RegionsController(App app) {
            this.app = app;
        }

        public async Task<IActionResult> Index(string sms) {
            ViewBag.ActiveMenu = "Master";
            TempData["Msg"] = sms;

            ViewBag.Regions = await app.Regions.AllAsync();

            return View();
        }

        public async Task<IActionResult> Create() {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Region item) {
            try {
                if (ModelState.IsValid) {
                    item.CreatedBy = User.Identity.Name;
                    await app.Regions.AddAsync(item);
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
                var item = await app.Regions.FindAsync(id);
                if (item == null) {
                    return RedirectToAction(nameof(Index), new { sms = "Item not found." });
                }

                await app.Regions.RemoveAsync(item);

                await app.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { sms = "Deleted" });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }

        }
    
    }
}
