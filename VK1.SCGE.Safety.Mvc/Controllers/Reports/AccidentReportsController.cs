using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Services;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace VK1.SCGE.Safety.Mvc.Controllers.Reports {
    public class AccidentReportsController : Controller {

        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly App app;

        public AccidentReportsController(App app) {
            this.app = app;
        }

        public async Task<List<VK1.SCGE.Safety.Models.Region>> Regions() => (await app.Regions.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Branch>> Branches() => (await app.Branches.AllAsyncAsNoTracking()).ToList();

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.Accident = "Accident";

            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name");

            ViewBag.Branches = new SelectList((await Branches()).Select(x => new { Id = x.BranchCode, x.Name }), "Id", "Name");


            return View();
        }

        public async Task<IActionResult> GetBranch(int id) {

            var data = await app.Branches.AllAsyncAsNoTracking();
            if (id != 0) {
                data = data.Where(x => x.RegionId == id);
            }

            return Json((data.Select(x => new { Id = x.BranchCode, Name = x.BranchCode }).ToList()));
        }

        public async Task<IActionResult> GetAll(DateTime from, DateTime to, int regionId, string branchCode) {
            ViewBag.From = from;
            ViewBag.To = to;
            ViewBag.Region = regionId;
            ViewBag.Branch = branchCode;

            var data = await app.InvestigateCards.QueryAsync(x =>
                                                from <= x.PartOne.CaseDate &&
                                                x.PartOne.CaseDate <= to);
            if (regionId != 0) {
                data = data.Where(x => x.PartOne.RegionId == regionId);
            }
            if (!String.IsNullOrEmpty(branchCode)) {
                data = data.Where(x => x.PartOne.BranchCode == branchCode);
            }

            string[] otherCodes = new string[] { "216", "311", "619", "813", "915" };

            var model = data.Select(x => new AccidentReportViewModel {
                //part one
                CaseDate = x.PartOne.CaseDate,
                RegionName = x.PartOne.RegionName,
                BranchCode = x.PartOne.BranchCode,
                CaseName = x.PartOne.CaseName,
                EmployeeName = x.PartOne.EmployeeName,
                Position = x.PartOne.PositionName,
                Age = x.PartOne.Age,
                YearExperience = $"{x.PartOne.YearExperience} ปี {x.PartOne.MonthExperience} เดือน {x.PartOne.DayExperience} วัน",
                CompanyName = x.PartOne.CompanyName,
                Shift = x.PartOne.Shift,
                CaseType = x.PartOne.CaseType.ToString(),
                AccidentMode = x.PartOne.AccidentMode.ToString(),
                Rank = (int)x.PartOne.Rank == 1 ? "เล็กน้อยไม่เข้าเกณฑ์" :
                      (int)x.PartOne.Rank == 2 ? "L1" :
                      (int)x.PartOne.Rank == 3 ? "L2" :
                      (int)x.PartOne.Rank == 3 ? "L3 หยุดงานรถคืนซาก" : "L3 เสียชีวิต",
                SolutionHour = $"{x.PartOne.SolutionHour} ชั่วโมง",

                //part two
                LeisureHour = $"{x.PartTwo.LeisureHour} ชั่วโมง",
                IncidentRoute = x.PartTwo.IncidentRoute.ToString(),
                ProductDamage = !x.PartTwo.IsProduct ? "ไม่มีสินค้า" :
                                x.PartTwo.IsProductDamage ? $"เสียหาย {x.PartTwo.ProductDamageQty} ชิ้น มูลค่า {x.PartTwo.ProductDamageValue} บาท" : "ไม่ได้รับความเสียหาย",
                CaseEffect = (int)x.PartTwo.CaseEffect == 1 ? "ส่งสินค้าต่อได้" : $"เลื่อนส่ง {x.PartTwo.ProductPostpone} ชิ้น",
                EmpInjure = (int)x.PartTwo.EmpInjure == 1 ? "ไม่ได้รับบาดเจ็บ" :
                          (int)x.PartTwo.EmpInjure == 2 ? $"{x.PartTwo.EmpInjureDescription}" :
                          (int)x.PartTwo.EmpInjure == 3 ? $"หยุดงาน {x.PartTwo.StopWorking} วัน" : "เสียชีวิต",
                PartiesInjure = (int)x.PartTwo.PartiesInjure == 1 ? "ไม่ได้รับบาดเจ็บ" :
                          (int)x.PartTwo.PartiesInjure == 2 ? $"{x.PartTwo.PartiesInjureDescription}" :
                          (int)x.PartTwo.PartiesInjure == 4 ? "เสียชีวิต" : null,
                ThirdPartiesInjure = (int)x.PartTwo.ThirdPartiesInjure == 1 ? "ไม่ได้รับบาดเจ็บ" :
                          (int)x.PartTwo.ThirdPartiesInjure == 2 ? $"{x.PartTwo.ThirdPartiesInjureDescription}" :
                          (int)x.PartTwo.ThirdPartiesInjure == 4 ? "เสียชีวิต" : null,
                TruckDamage = (int)x.PartTwo.TruckDamage == 1 ? "ไม่เสียหาย" :
                            (int)x.PartTwo.TruckDamage == 2 ? $"{x.PartTwo.TruckDamageDescription}" : null,
                PartiesDamage = (int)x.PartTwo.PartiesDamage == 1 ? "ไม่เสียหาย" :
                            (int)x.PartTwo.PartiesDamage == 3 ? $"{x.PartTwo.PartiesDamageDescription}" : null,
                EquipmentDamage = (int)x.PartTwo.EquipmentDamage == 1 ? "ไม่เสียหาย" :
                            (int)x.PartTwo.EquipmentDamage == 3 ? $"{x.PartTwo.EquipmentDamageDescription}" : null,
                Camera = (int)x.PartTwo.Camera == 1 ? "ปกติ" :
                        (int)x.PartTwo.Camera == 2 ? "กล้องเสีย" : "ไม่มีกล้อง",
                TruckInspectionNormal = x.PartTwo.IsTruckInspectionNormal ? "ปกติ" : $"{x.PartTwo.TruckInspectionDescription}",
                Gps = x.PartTwo.IsGps ? "มีการติดตั้ง" : "ไม่มีการติดตั้ง",
                GpsSpeed = $"{x.PartTwo.GpsSpeed} กม./ชม.",
                Cctv = x.PartTwo.IsCctv ? "มี" : "ไม่มี",
                SafetyCourse = x.PartTwo.IsPassSafetyCourse ? "ผ่าน" : "ไม่ผ่าน",
                SdcCourse = x.PartTwo.IsPassSDC ? "ผ่าน" : "ไม่ผ่าน",
                AlcoholCheck = x.PartTwo.IsPassAlcohol ? "ผ่าน" : "ไม่ผ่าน",

                //part three
                IncidentDescription = x.PartThree.IncidentDescription,

                //part four
                AreaConditon = x.PartFour.AreaConditionId == 16 ? x.PartFour.AreaConditionDescription :
                                                             x.PartFour.AreaCondition.Name,
                Weather = x.PartFour.WeatherId == 8 ? x.PartFour.WeatherDescription : x.PartFour.Weather.Name,
                Traffic = x.PartFour.Traffic.Name,
                IncidentArea = x.PartFour.IncidentAreaId == 16 ? x.PartFour.IncidentAreaDescription : x.PartFour.IncidentArea.Name,
                Incident = x.PartFour.IncidentDepotId == null ?
                         x.PartFour.IncidentRoadId == 15 ? x.PartFour.IncidentRoadDescription :
                         x.PartFour.IncidentRoad.Name :
                         x.PartFour.IncidentDepotId == 1 ? x.PartFour.IncidentDepotDescription :
                         x.PartFour.IncidentDepot.Name,

                UnsafeActs = (x.PartFive.PartFiveDetails.Where(x => (int)x.UnsafeItem.UnsafeCategory.UnsafeType == 1).Select(x => new UnsafeActViewModel {
                    Name = otherCodes.Contains(x.UnsafeItemCode) ? x.Description : x.UnsafeItem.Name
                })).ToList(),

                UnsafeCons = (x.PartFive.PartFiveDetails.Where(x => (int)x.UnsafeItem.UnsafeCategory.UnsafeType == 2).Select(x => new UnsafeActViewModel {
                    Name = otherCodes.Contains(x.UnsafeItemCode) ? x.Description : x.UnsafeItem.Name
                })).ToList(),

                Solutions = (x.PartSixes.Select(x => x.Solution)).ToList()

            });

            return PartialView("pv_Table", model.ToList());

        }

        public async Task<IActionResult> ExportToExcel(DateTime from, DateTime to, int regionId, string branchCode) {
            try {

                #region Get data
                var query = await app.InvestigateCards.QueryAsync(x =>
                                                from <= x.PartOne.CaseDate &&
                                                x.PartOne.CaseDate <= to);
                if (regionId != 0) {
                    query = query.Where(x => x.PartOne.RegionId == regionId);
                }
                if (!String.IsNullOrEmpty(branchCode)) {
                    query = query.Where(x => x.PartOne.BranchCode == branchCode);
                }

                string[] otherCodes = new string[] { "216", "311", "619", "813", "915" };
                var data = query.Select(x => new AccidentReportViewModel {
                    //part one
                    CaseDate = x.PartOne.CaseDate,
                    RegionName = x.PartOne.RegionName,
                    BranchCode = x.PartOne.BranchCode,
                    CaseName = x.PartOne.CaseName,
                    EmployeeName = x.PartOne.EmployeeName,
                    Position = x.PartOne.PositionName,
                    Age = x.PartOne.Age,
                    YearExperience = $"{x.PartOne.YearExperience} ปี {x.PartOne.MonthExperience} เดือน {x.PartOne.DayExperience} วัน",
                    CompanyName = x.PartOne.CompanyName,
                    Shift = x.PartOne.Shift,
                    CaseType = x.PartOne.CaseType.ToString(),
                    AccidentMode = x.PartOne.AccidentMode.ToString(),
                    Rank = (int)x.PartOne.Rank == 1 ? "เล็กน้อยไม่เข้าเกณฑ์" :
                    (int)x.PartOne.Rank == 2 ? "L1" :
                    (int)x.PartOne.Rank == 3 ? "L2" :
                    (int)x.PartOne.Rank == 3 ? "L3 หยุดงานรถคืนซาก" : "L3 เสียชีวิต",
                    SolutionHour = $"{x.PartOne.SolutionHour} ชั่วโมง",

                    //part two
                    LeisureHour = $"{x.PartTwo.LeisureHour} ชั่วโมง",
                    IncidentRoute = x.PartTwo.IncidentRoute.ToString(),
                    ProductDamage = !x.PartTwo.IsProduct ? "ไม่มีสินค้า" :
                              x.PartTwo.IsProductDamage ? $"เสียหาย {x.PartTwo.ProductDamageQty} ชิ้น มูลค่า {x.PartTwo.ProductDamageValue} บาท" : "ไม่ได้รับความเสียหาย",
                    CaseEffect = (int)x.PartTwo.CaseEffect == 1 ? "ส่งสินค้าต่อได้" : $"เลื่อนส่ง {x.PartTwo.ProductPostpone} ชิ้น",
                    EmpInjure = (int)x.PartTwo.EmpInjure == 1 ? "ไม่ได้รับบาดเจ็บ" :
                        (int)x.PartTwo.EmpInjure == 2 ? $"{x.PartTwo.EmpInjureDescription}" :
                        (int)x.PartTwo.EmpInjure == 3 ? $"หยุดงาน {x.PartTwo.StopWorking} วัน" : "เสียชีวิต",
                    PartiesInjure = (int)x.PartTwo.PartiesInjure == 1 ? "ไม่ได้รับบาดเจ็บ" :
                        (int)x.PartTwo.PartiesInjure == 2 ? $"{x.PartTwo.PartiesInjureDescription}" :
                        (int)x.PartTwo.PartiesInjure == 4 ? "เสียชีวิต" : null,
                    ThirdPartiesInjure = (int)x.PartTwo.ThirdPartiesInjure == 1 ? "ไม่ได้รับบาดเจ็บ" :
                        (int)x.PartTwo.ThirdPartiesInjure == 2 ? $"{x.PartTwo.ThirdPartiesInjureDescription}" :
                        (int)x.PartTwo.ThirdPartiesInjure == 4 ? "เสียชีวิต" : null,
                    TruckDamage = (int)x.PartTwo.TruckDamage == 1 ? "ไม่เสียหาย" :
                          (int)x.PartTwo.TruckDamage == 2 ? $"{x.PartTwo.TruckDamageDescription}" : null,
                    PartiesDamage = (int)x.PartTwo.PartiesDamage == 1 ? "ไม่เสียหาย" :
                          (int)x.PartTwo.PartiesDamage == 3 ? $"{x.PartTwo.PartiesDamageDescription}" : null,
                    EquipmentDamage = (int)x.PartTwo.EquipmentDamage == 1 ? "ไม่เสียหาย" :
                          (int)x.PartTwo.EquipmentDamage == 3 ? $"{x.PartTwo.EquipmentDamageDescription}" : null,
                    Camera = (int)x.PartTwo.Camera == 1 ? "ปกติ" :
                      (int)x.PartTwo.Camera == 2 ? "กล้องเสีย" : "ไม่มีกล้อง",
                    TruckInspectionNormal = x.PartTwo.IsTruckInspectionNormal ? "ปกติ" : $"{x.PartTwo.TruckInspectionDescription}",
                    Gps = x.PartTwo.IsGps ? "มีการติดตั้ง" : "ไม่มีการติดตั้ง",
                    GpsSpeed = $"{x.PartTwo.GpsSpeed} กม./ชม.",
                    Cctv = x.PartTwo.IsCctv ? "มี" : "ไม่มี",
                    SafetyCourse = x.PartTwo.IsPassSafetyCourse ? "ผ่าน" : "ไม่ผ่าน",
                    SdcCourse = x.PartTwo.IsPassSDC ? "ผ่าน" : "ไม่ผ่าน",
                    AlcoholCheck = x.PartTwo.IsPassAlcohol ? "ผ่าน" : "ไม่ผ่าน",

                    //part three
                    IncidentDescription = x.PartThree.IncidentDescription,

                    //part four
                    AreaConditon = x.PartFour.AreaConditionId == 16 ? x.PartFour.AreaConditionDescription :
                                                           x.PartFour.AreaCondition.Name,
                    Weather = x.PartFour.WeatherId == 8 ? x.PartFour.WeatherDescription : x.PartFour.Weather.Name,
                    Traffic = x.PartFour.Traffic.Name,
                    IncidentArea = x.PartFour.IncidentAreaId == 16 ? x.PartFour.IncidentAreaDescription : x.PartFour.IncidentArea.Name,
                    Incident = x.PartFour.IncidentDepotId == null ?
                       x.PartFour.IncidentRoadId == 15 ? x.PartFour.IncidentRoadDescription :
                       x.PartFour.IncidentRoad.Name :
                       x.PartFour.IncidentDepotId == 1 ? x.PartFour.IncidentDepotDescription :
                       x.PartFour.IncidentDepot.Name,

                    UnsafeActs = (x.PartFive.PartFiveDetails.Where(x => (int)x.UnsafeItem.UnsafeCategory.UnsafeType == 1).Select(x => new UnsafeActViewModel {
                        Name = otherCodes.Contains(x.UnsafeItemCode) ? x.Description : x.UnsafeItem.Name
                    })).ToList(),

                    UnsafeCons = (x.PartFive.PartFiveDetails.Where(x => (int)x.UnsafeItem.UnsafeCategory.UnsafeType == 2).Select(x => new UnsafeActViewModel {
                        Name = otherCodes.Contains(x.UnsafeItemCode) ? x.Description : x.UnsafeItem.Name
                    })).ToList(),

                    Solutions = (x.PartSixes.Select(x => x.Solution)).ToList()

                });

                #endregion

                byte[] reportBytes;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage();
                package.Workbook.Properties.Title = "Accident Report";
                package.Workbook.Properties.Author = "Tatthep M.";
                package.Workbook.Properties.Subject = "Accident Report";
                package.Workbook.Properties.Keywords = "ACcident Report";
                var worksheet = package.Workbook.Worksheets.Add("AccidentReport");

                //First add the headers
                //worksheet.Cells["A1:AP1"].Merge = true;
                //worksheet.Cells["A1:AP1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //worksheet.Cells["A1:AP1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                worksheet.Cells["A1"].Value = "รายงานอุบัติเหตุ";

                #region header table
                string[] headers = new string[] { "#", "วันที่เกิดเหตุ", "หน่วยงาน", "สาขา", "ชื่อเคส", "ชื่อพนักงาน", "ตำแหน่ง", "อายุพนักงาน", "อายุงาน", "สังกัดบริษัทฯ", "กะการทำงาน", "ประเมินความผิด", "ประเภทของอุบัติเหตุ", "ระดับความรุนแรง", "ระยะเวลาตั้งแต่เกิดจนแล้วเสร็จ", "เวลาพักผ่อน", "เส้นทางที่วิ่ง", "สินค้าหลังตู้รถขณะเกิดเหตุ", "การดำเนินการ", "การบาดเจ็บของพนักงาน", "การบาดเจ็บของคู่กรณี", "การบาดเจ็บของบุคคลที่ 3", "ความเสียหายของรถ", "ความเสียหายของรถคู่กรณี", "ความเสียหายของอุปกรณ์", "กล้องหน้ารถ", "การตรวจสภาพรถ", "GPS", "ความเร็วขณะเกิดเหตุ", "กล้องวงจรปิด", "อบรมความปลอดภัย", "อบรม SDC", "ผลการตรวจแอลกอฮอล์", "รายละเอียด", "สภาพพื้นที่", "สภาพอากาศ", "การจราจร", "ลักษณะบริเวณเกิดเหตุ", "ลักษณะอุบัติเหตุ", "สาเหตุของอุบัติเหต Unsafe Act.", "สาเหตุของอุบัติเหตุ Unsafe Con.", "มาตรการป้องกันที่ดำเนินการ" };

                string[] greens = new string[] { "#", "วันที่เกิดเหตุ", "หน่วยงาน", "สาขา", "ชื่อเคส", "ชื่อพนักงาน", "ตำแหน่ง", "สังกัดบริษัทฯ", "ประเมินความผิด", "ประเภทของอุบัติเหตุ", "ระดับความรุนแรง", "การบาดเจ็บของพนักงาน", "ความเสียหายของรถ", "กล้องหน้ารถ", "ความเร็วขณะเกิดเหตุ", "รายละเอียด", "ลักษณะอุบัติเหตุ", "สาเหตุของอุบัติเหต Unsafe Act.", "สาเหตุของอุบัติเหตุ Unsafe Con.", "มาตรการป้องกันที่ดำเนินการ" };

                for (int h = 0; h < headers.Length; h++) {
                    worksheet.Cells[2, h + 1].Value = headers[h];
                    worksheet.Cells[2, h + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, h + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, h + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, h + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    if (greens.Contains(worksheet.Cells[2, h + 1].Value)) {
                        worksheet.Cells[2, h + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[2, h + 1].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#009C87"));
                    }

                }
                #endregion

                #region data table
                var row = 3;
                var itemNo = 1;
                var lastRow = 0;
                int max = 0;
                foreach (var item in data) {
                    worksheet.Cells[row, 1].Value = itemNo;
                    worksheet.Cells[row, 2].Value = item.CaseDate;
                    worksheet.Cells[row, 2].Style.Numberformat.Format = "dd-MM-yyyy";
                    worksheet.Cells[row, 3].Value = item.RegionName;
                    worksheet.Cells[row, 4].Value = item.BranchCode;
                    worksheet.Cells[row, 5].Value = item.CaseName;
                    worksheet.Cells[row, 6].Value = item.EmployeeName;
                    worksheet.Cells[row, 7].Value = item.Position;
                    worksheet.Cells[row, 8].Value = item.Age;
                    worksheet.Cells[row, 9].Value = item.YearExperience;
                    worksheet.Cells[row, 10].Value = item.CompanyName;
                    worksheet.Cells[row, 11].Value = item.Shift;
                    worksheet.Cells[row, 12].Value = item.CaseType;
                    worksheet.Cells[row, 13].Value = item.AccidentMode;
                    worksheet.Cells[row, 14].Value = item.Rank;
                    worksheet.Cells[row, 15].Value = item.SolutionHour;
                    worksheet.Cells[row, 16].Value = item.LeisureHour;
                    worksheet.Cells[row, 17].Value = item.IncidentRoute;
                    worksheet.Cells[row, 18].Value = item.ProductDamage;
                    worksheet.Cells[row, 19].Value = item.CaseEffect;
                    worksheet.Cells[row, 20].Value = item.EmpInjure;
                    worksheet.Cells[row, 21].Value = item.PartiesInjure;
                    worksheet.Cells[row, 22].Value = item.ThirdPartiesInjure;
                    worksheet.Cells[row, 23].Value = item.TruckDamage;
                    worksheet.Cells[row, 24].Value = item.PartiesDamage;
                    worksheet.Cells[row, 25].Value = item.EquipmentDamage;
                    worksheet.Cells[row, 26].Value = item.Camera;
                    worksheet.Cells[row, 27].Value = item.TruckInspectionNormal;
                    worksheet.Cells[row, 28].Value = item.Gps;
                    worksheet.Cells[row, 29].Value = item.GpsSpeed;
                    worksheet.Cells[row, 30].Value = item.Cctv;
                    worksheet.Cells[row, 31].Value = item.SafetyCourse;
                    worksheet.Cells[row, 32].Value = item.SdcCourse;
                    worksheet.Cells[row, 33].Value = item.AlcoholCheck;
                    worksheet.Cells[row, 34].Value = item.IncidentDescription;
                    worksheet.Cells[row, 35].Value = item.AreaConditon;
                    worksheet.Cells[row, 36].Value = item.Weather;
                    worksheet.Cells[row, 37].Value = item.Traffic;
                    worksheet.Cells[row, 38].Value = item.IncidentArea;
                    worksheet.Cells[row, 39].Value = item.Incident;
                    foreach (var unsafeact in item.UnsafeActs) {
                        worksheet.Cells[row, 40].Value = unsafeact.Name;
                        row++;
                    }
                    row -= item.UnsafeActs.Count;
                    foreach (var unsafecon in item.UnsafeCons) {
                        worksheet.Cells[row, 41].Value = unsafecon.Name;
                        row++;
                    }
                    row -= item.UnsafeCons.Count;
                    foreach (var solution in item.Solutions) {
                        worksheet.Cells[row, 42].Value = solution;
                        row++;
                    }

                    int[] counts = new int[] { item.UnsafeActs.Count, item.UnsafeCons.Count, item.Solutions.Count };
                    max = counts.Max();

                    itemNo = ((itemNo + max) - max) + 1;
                }

                lastRow = itemNo + max + max;
                worksheet.Cells[3, 1, lastRow, 42].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                #endregion

                reportBytes = package.GetAsByteArray();

                return await Task.FromResult(File(reportBytes, XlsxContentType, "AccidentReport.xlsx"));
            } catch (Exception) {

                throw;
            }
        }
    }
}
