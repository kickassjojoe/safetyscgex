using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Mvc.Dtos;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TruckInspectionCardApiController : ControllerBase {
        private readonly App app;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TruckInspectionCardApiController(App app, IWebHostEnvironment webHostEnvironment) {
            this.app = app;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("addcard")]
        public async Task<IActionResult> AddCard(TruckInspectionCardAddDto item) {
            try {
                var vehicleId = Convert.ToInt32(item.Vehicle);
                var _vehicle = await app.Vehicles.FindAsync(vehicleId);

                var isNotCompleteOdometer = await app.TruckInspectionCards.AnyAsync(x => x.VehicleId == vehicleId && x.FinishedOdometer == 0);

                if (isNotCompleteOdometer) {
                    return StatusCode(405, new { message = $"{_vehicle.PlateNumber} ยังไม่บันทึกไมล์ขากลับ" });
                }

                var card = new TruckInspectionCard();
                List<TruckInspectionCardDetail> list = new List<TruckInspectionCardDetail>();
                foreach (var u in item.UserData) {
                    TruckInspectionCardDetail detail = new TruckInspectionCardDetail();
                    if (u.IsNormal == "true") {
                        detail.IsNormal = true;
                    } else if (u.IsNormal == "false") {
                        detail.IsNormal = false;
                    }
                    detail.TruckInspectionItemId = u.TruckInspectionId;
                    detail.PicturePath = u.File;
                    detail.Remark = u.Remark;
                    detail.CreatedBy = item.EmployeeCode;
                    detail.CreatedDate = DateTime.Now;
                    list.Add(detail);

                    card.EmployeeCode = item.EmployeeCode; card.EmployeeName = item.EmployeeName; card.VehicleId = _vehicle.Id;
                    card.PlateNumber = _vehicle.PlateNumber; card.InspectionDate = DateTime.Today; card.StartOdometer = item.StartOdometer;
                    card.CreatedBy = item.EmployeeCode;
                    card.RegionId = _vehicle.RegionId;
                    card.RegionName = _vehicle.RegionName;
                    card.BranchCode = _vehicle.BranchCode;
                    card.BranchName = _vehicle.Branch.Name;
                    card.VehicleType = _vehicle.VehicleType;
                    // card.AddDetail(detail);
                }
                //update vehicle
                _vehicle.IsUse = true;
                await app.Vehicles.UpdateAsync(_vehicle);

                // add card control
                var mm = DateTime.Now.ToString("MM");
                var yyyy = DateTime.Now.ToString("yyyy");
                var cardCode = $"{mm}{yyyy}";
                int tid = 0;
                var cardControl = await app.CardControls.FindAsync(cardCode);
                if (cardControl == null) {
                    CardControl c = new CardControl();
                    c.Code = cardCode;
                    c.Month = DateTime.Now.Month;
                    c.Year = DateTime.Now.Year;
                    c.AddCard(card, list);
                    await app.CardControls.AddAsync(c);
                    await app.SaveChangesAsync();
                    tid = c.Cards.LastOrDefault().TruckInspectionCardId;
                } else {
                    cardControl.AddCard(card, list);
                    await app.CardControls.UpdateAsync(cardControl);
                    await app.SaveChangesAsync();
                    tid = cardControl.Cards.LastOrDefault().TruckInspectionCardId;
                }
                var result = new TruckInspectionCardResponse {
                    TruckInspectionCardId = tid, //contro .TruckInspectionCardId,
                    EmployeeCode = card.EmployeeCode,
                    EmployeeName = card.EmployeeName,
                    VehicleId = card.VehicleId,
                    PlateNumber = card.PlateNumber,
                    InspectionDate = card.InspectionDate,
                    StartOdometer = card.StartOdometer,
                };
                return Ok(result);

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return StatusCode(405, message);

            }
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload() {
            try {
                var collection = Request.Form;
                var plateNumber = "";
                var cardId = 0;
                foreach (var item in collection) {
                    switch (item.Key) {
                        case "vehicle":
                            plateNumber = (await app.Vehicles.FindAsync(Convert.ToInt32(item.Value.ToString()))).PlateNumber;
                            break;
                        case "cardId":
                            cardId = Convert.ToInt32(item.Value.ToString());
                            break;
                    }

                }

                foreach (var file in Request.Form.Files) {
                    var fileName = file.FileName;
                    var names = fileName.Split('_').Select(x => x.Trim()).ToArray();
                    fileName = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}_{plateNumber}_{names[2]}_{cardId}.png";

                    var imgPath = $@"wwwroot\resources\images\{fileName}";

                    var fullPath = Path.Combine(webHostEnvironment.WebRootPath,
                                               "resources", "images",
                                               fileName);

                    var sql = $"UPDATE TruckInspectionCardDetails SET PicturePath=N'{imgPath}' WHERE TruckInspectionItemId={names[2]} AND TruckInspectionCardId={cardId}";

                    await app.ExecuteToSqlAsync(sql);

                    using (var fileStream = new FileStream(fullPath, FileMode.Create)) {
                        await file.CopyToAsync(fileStream);
                    }
                }

                return Ok();

            } catch (Exception ex) {
                return StatusCode(500, $"Internal Server Error {ex}");
            }
        }
    }
}
