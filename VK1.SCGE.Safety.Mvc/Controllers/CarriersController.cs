using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    public class CarriersController : Controller {
        private readonly App app;

        public CarriersController(App app) {
            this.app = app;
        }

        public async Task<IActionResult> Index(string sms) {
            ViewBag.ActiveMenu = "Master";
            TempData["Msg"] = sms;

            ViewBag.Carriers = await app.Carries.AllAsync();

            return View();
        }

        public async Task<IActionResult> Create() {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Carrier item) {
            try {
                if (ModelState.IsValid) {
                    item.CreatedBy = User.Identity.Name;
                    await app.Carries.AddAsync(item);
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
                var item = await app.Carries.FindAsync(id);
                if (item == null) {
                    return RedirectToAction(nameof(Index), new { sms = "Item not found." });
                }

                await app.Carries.RemoveAsync(item);

                await app.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { sms = "Deleted" });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }

        }


    }
}
