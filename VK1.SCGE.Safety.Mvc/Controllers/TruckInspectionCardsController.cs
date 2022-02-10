using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VK1.SCGE.Safety.Mvc.Dtos;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Authorize]
    public class TruckInspectionCardsController : Controller {
        private readonly App app;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TruckInspectionCardsController(App app, IWebHostEnvironment webHostEnvironment) {
            this.app = app;
            this.webHostEnvironment = webHostEnvironment;
        }

        [Route("truckinspectioncard")]
        public IActionResult Index() {
            ViewBag.ActiveMenu = "Card";

            if (GlobalData.LoginUserName == null) {
                return RedirectToAction(nameof(HomeController.Logout), "Home");
            }

            var html = System.IO.File.ReadAllText(System.IO.Path.Combine(webHostEnvironment.WebRootPath, "truckinspectioncard", "index.html"));

            //const string markerCss1 = "<link rel=\"stylesheet\"";
            //const string markerCss2 = ">";
            //var indexCss1 = html.IndexOf(markerCss1);
            //var indexCss2 = html.IndexOf(markerCss2, indexCss1 + 1);
            //var css = html.Substring(indexCss1, indexCss2 - indexCss1 + markerCss2.Length);

            const string markerBody1 = "<body>";
            const string markerBody2 = "</body>";
            var indexBody1 = html.IndexOf(markerBody1) + markerBody1.Length;
            var indexBody2 = html.IndexOf(markerBody2);
            var body = html.Substring(indexBody1, indexBody2 - indexBody1);

            //css = css.Replace("href=\"", "href=\"truckinspectioncard\\");
            body = body.Replace("src=\"", "src=\"truckinspectioncard\\");

            //ViewBag.Head = css;
            ViewBag.Body = body;

            return View();
        }

        public async Task<IActionResult> UpdateOdometer(string sms) {
            TempData["Msg"] = sms;
            ViewBag.ActiveMenu = "Card";
            ViewBag.Count = 0;

            var vehicles = (await app.Vehicles.AllAsyncAsNoTracking()).Select(x => new {
                x.Id,
                Name = x.PlateNumber
            });

            ViewBag.Vehicles = new SelectList(vehicles, "Id", "Name");

            return View();

        }

        public async Task<IActionResult> GetAll(string datestring, int? vehicleId) {
            var date = GlobalData.DayMontYearToYearMonthDay(datestring);
            var query = await app.TruckInspectionCards.QueryAsyncAsNoTracking(x => date <= x.CreatedDate && x.CreatedDate <= date.AddDays(1));
            if (vehicleId != null) {
                query = query.Where(x => x.VehicleId == vehicleId);
            }

            ViewBag.Count = query.Count();
            ViewBag.Cards = query.ToList();

            return PartialView("_Table");
        }

        public async Task<IActionResult> GetAllToday() {
            var date = DateTime.Today;
            var query = await app.TruckInspectionCards.QueryAsyncAsNoTracking(x => date <= x.CreatedDate && x.CreatedDate <= date.AddDays(1));

            ViewBag.Count = query.Count();
            ViewBag.Cards = query.ToList();

            return PartialView("_Table");
        }

        public IActionResult AddFinishedOdometer(int id) {
            ViewBag.CardId = id;
            var model = new OdometerDto {
                TruckInspectionCardId = id,
            };

            return PartialView("_FinishedOdometer", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFinishedOdometer(OdometerDto item) {
            try {
                var odometer = Convert.ToInt32(item.Odometer);
                var card = await app.TruckInspectionCards.FindAsync(item.TruckInspectionCardId);
                if (card == null) {
                    return RedirectToAction(nameof(UpdateOdometer), new { sms = "Data not found." });
                }

                card.FinishedOdometer = odometer;
                card.AddOdometer(odometer);

                await app.TruckInspectionCards.UpdateAsync(card);

                //update vehicle
                var vehicle = await app.Vehicles.FindAsync(card.VehicleId);
                vehicle.IsUse = false;
                await app.Vehicles.UpdateAsync(vehicle);

                await app.SaveChangesAsync();

                // return RedirectToAction(nameof(UpdateOdometer), new { sms = "บันทึกสำเร็จ" });
                return Json("บันทึกสำเร็จ");

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                // return RedirectToAction(nameof(UpdateOdometer), new { sms = message });
                return Json("Error : " + message);
            }
        }
    }
}