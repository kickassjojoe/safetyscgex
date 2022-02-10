using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers.Reports {
    public class DailyReportsController : Controller {
        private readonly App app;

        public DailyReportsController(App app) {
            this.app = app;
        }

        public async Task<List<Vehicle>> Vehicles() => (await app.Vehicles.AllAsyncAsNoTracking()).ToList();

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;

            ViewBag.Vehicles = new SelectList((await Vehicles()).Select(x => new { x.Id, Name = x.PlateNumber }), "Id", "Name");

            return View();
        }

        public async Task<IActionResult> GetCard(int vehicleId, string strDate) {
            //01/09/2020
            var inspectionDate = new DateTime(Convert.ToInt32(strDate.Substring(6, 4)),
                                              Convert.ToInt32(strDate.Substring(3, 2)),
                                              Convert.ToInt32(strDate.Substring(0, 2)));

            var model = await DictionaryCard(vehicleId, inspectionDate);
            ViewBag.Date = strDate;
            return PartialView("_Table", model);
        }

        public async Task<Dictionary<TruckInspectionCard,List<TruckInspectionCardDetail>>> DictionaryCard(int vehicleId,DateTime inspectionDate) {

            var data = (await app.TruckInspectionCards.QueryAsync(x => x.VehicleId == vehicleId && x.InspectionDate == inspectionDate)).FirstOrDefault();

            if (data == null) {
                return null;
            }
            Dictionary<TruckInspectionCard, List<TruckInspectionCardDetail>> dictionary = new Dictionary<TruckInspectionCard, List<TruckInspectionCardDetail>>();

            dictionary.Add(data, (data.TruckInspectionCardDetails).ToList());

            return dictionary;
        }

        [HttpPost]
        public async Task<IActionResult> ExportPdf(int vehicleId, DateTime inspectionDate) {
            var model = await DictionaryCard(vehicleId, inspectionDate);
            var filename = $"{model.FirstOrDefault().Key.PlateNumber}.pdf";

            return new ViewAsPdf("DailyReportAsPdf", model) {
                CustomSwitches = "--footer-center \"  Created Date: " +
                                          DateTime.Now.Date.ToString("dd/MM/yyyy") +
                                          "  Page: [page]/[toPage]\"" +
                                          " --disable-smart-shrinking" +
                                          " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Segoe UI\"",
                PageMargins = { Left = 10, Bottom = 10, Right = 5, Top = 12 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                FileName = filename
            };

        }
    }
}
