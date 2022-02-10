using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Authorize]
    public class CARApprovesController : Controller {
        private readonly App app;

        public CARApprovesController(App app) {
            this.app = app;
        }

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.ActiveMenu = "Card";

           ViewBag.Model = await app.CAR.QueryAsyncAsNoTracking(x => x.CARStatusCode != "300");

            return View();
        }

        public async Task<IActionResult> GetAllCAR(string prefix) {
            var data = (await app.CAR.QueryAsync(x => x.CARCode.StartsWith(prefix)
                                                && x.CARStatusCode != "300"))
                                                .Select(
                                                        x => new { x.CARCode }
                                                        ).ToList().OrderBy(x=>x.CARCode);

            return Json(data);
        }

        public async Task<IActionResult> GetAllCARItem(string id) {

            var model = await app.CARItem.QueryAsync(x => x.CARCode == id);

            ViewBag.CARCode = id;
            ViewBag.Count = model.Count();

            return PartialView("_Table", model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCAR(int[] chk, string carcode) {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try {
                if (chk.Count() == 0) {
                    return RedirectToAction(nameof(Index), new { sms = "Data not found." });
                }

                var car = await app.CAR.FindAsync(carcode);
                car.Approve(User.Identity.Name,chk);
                await app.CAR.UpdateAsync(car);

                await app.SaveChangesAsync();

                scope.Complete();

                return RedirectToAction(nameof(Index), new { sms = "บันทึกสำเร็จ" });

            } catch (Exception) {

                throw;
            };

        }
    }
}
