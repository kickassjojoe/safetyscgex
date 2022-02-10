using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.CodeAnalysis.CSharp;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Mvc.Models.ReportViewModels;
using VK1.SCGE.Safety.Services;


namespace VK1.SCGE.Safety.Mvc.Controllers.Reports {
    [Authorize]
    public class DistanceReportsController : Controller {
        private readonly AppQuery appQuery;
        private readonly App app;
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private readonly List<Month> months = new List<Month>() {
                new Month(){Id=1,Name="มกราคม"},
                new Month(){Id=2,Name="กุมภาพันธ์"},
                new Month(){Id=3,Name="มีนาคม"},
                new Month(){Id=4,Name="เมษายน"},
                new Month(){Id=5,Name="พฤษภาคม"},
                new Month(){Id=6,Name="มิถุนายน"},
                new Month(){Id=7,Name="กรกฎาคม"},
                new Month(){Id=8,Name="สิงหาคม"},
                new Month(){Id=9,Name="กันยายน"},
                new Month(){Id=10,Name="ตุลาคม"},
                new Month(){Id=11,Name="พฤศจิกายน"},
                new Month(){Id=12,Name="ธันวาคม"}
        };

        public DistanceReportsController(AppQuery appQuery, App app) {
            this.appQuery = appQuery;
            this.app = app;
        }

        private async Task<List<Branch>> Branches() => (await app.Branches.AllAsyncAsNoTracking()).ToList();

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;

            ViewBag.Branches = new SelectList(from x in await Branches()
                                              select new { Id = x.BranchCode, x.Name }, "Id", "Name");

            ViewBag.MBranches = new SelectList(from x in await Branches()
                                               select new { Id = x.BranchCode, x.Name }, "Id", "Name");

            ViewBag.Months = new SelectList(months.Select(x => new { x.Id, x.Name }), "Id", "Name");

            return View();
        }

        public async Task<IActionResult> GetDistanceYear(int id) {
            ViewBag.Year = id;
            var strSql = $"EXEC uspYearlyDistance {id}";
            var data = await appQuery.YearlyDistanceAsync<YearlyDistanceViewModel>(strSql);
            ViewBag.DistanceYear = data.ToList();

            return PartialView("_TableDistanceYear");
        }

        public async Task<IActionResult> ExcelDistanceYear(int id) {
            try {
                var strSql = $"EXEC uspYearlyDistance {id}";
                var data = (await appQuery.YearlyDistanceAsync<YearlyDistanceViewModel>(strSql)).ToList();

                byte[] reportBytes;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage()) {
                    package.Workbook.Properties.Title = "Yearly Distance Report";
                    package.Workbook.Properties.Author = "Tatthep M.";
                    package.Workbook.Properties.Subject = "Yearly Distance Report";
                    package.Workbook.Properties.Keywords = "Yearly Distance Report";
                    var worksheet = package.Workbook.Worksheets.Add("YearlyDistanceReport");

                    //First add the headers
                    worksheet.Cells["A1:N1"].Merge = true;
                    worksheet.Cells["A1:N1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1:N1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells["A1"].Value = "เลขระยะทางรวมปี " + $"{id}";

                    worksheet.Cells[2, 1].Value = "ภาค";
                    worksheet.Cells[2, 2].Value = "ม.ค.";
                    worksheet.Cells[2, 3].Value = "ก.พ.";
                    worksheet.Cells[2, 4].Value = "มี.ค.";
                    worksheet.Cells[2, 5].Value = "เม.ย.";
                    worksheet.Cells[2, 6].Value = "พ.ค.";
                    worksheet.Cells[2, 7].Value = "มิ.ย.";
                    worksheet.Cells[2, 8].Value = "ก.ค.";
                    worksheet.Cells[2, 9].Value = "ส.ค.";
                    worksheet.Cells[2, 10].Value = "ก.ย.";
                    worksheet.Cells[2, 11].Value = "ต.ค.";
                    worksheet.Cells[2, 12].Value = "พ.ย.";
                    worksheet.Cells[2, 13].Value = "ธ.ค.";
                    worksheet.Cells[2, 14].Value = "รวม";
                    worksheet.Cells[2, 1, 2, 14].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, 1, 2, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, 1, 2, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[2, 1, 2, 14].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    var row = 3;

                    int totalRegion = 0, totJan = 0, totFeb = 0, totMar = 0, totApr = 0, totMay = 0, totJun = 0, totJul = 0, totAug = 0, totSep = 0, totOct = 0, totNov = 0, totDec = 0, GranTotal = 0;
                    foreach (var item in data) {
                        var jan = item.January ?? 0; totJan += jan;
                        var feb = item.February ?? 0; totFeb += feb;
                        var mar = item.March ?? 0; totMar += mar;
                        var apr = item.April ?? 0; totApr += apr;
                        var may = item.May ?? 0; totMay += may;
                        var jun = item.June ?? 0; totJun += jun;
                        var jul = item.July ?? 0; totJul += jul;
                        var aug = item.August ?? 0; totAug += aug;
                        var sep = item.September ?? 0; totSep += sep;
                        var oct = item.October ?? 0; totOct += oct;
                        var nov = item.November ?? 0; totNov += nov;
                        var dec = item.December ?? 0; totDec += dec;
                        totalRegion = jan + feb + mar + apr + may + jun + jul + aug + sep + oct + nov + dec;
                        GranTotal += totalRegion;

                        worksheet.Cells[row, 1].Value = item.RegionName;
                        worksheet.Cells[row, 2].Value = jan;
                        worksheet.Cells[row, 3].Value = feb;
                        worksheet.Cells[row, 4].Value = mar;
                        worksheet.Cells[row, 5].Value = apr;
                        worksheet.Cells[row, 6].Value = may;
                        worksheet.Cells[row, 7].Value = jun;
                        worksheet.Cells[row, 8].Value = jul;
                        worksheet.Cells[row, 9].Value = aug;
                        worksheet.Cells[row, 10].Value = sep;
                        worksheet.Cells[row, 12].Value = nov;
                        worksheet.Cells[row, 13].Value = dec;
                        worksheet.Cells[row, 14].Value = totalRegion;

                        worksheet.Cells[row, 1, row, 14].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 14].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                        row++;
                    }
                    worksheet.Cells[row, 1].Value = "รวม";
                    worksheet.Cells[row, 2].Value = totJan;
                    worksheet.Cells[row, 3].Value = totFeb;
                    worksheet.Cells[row, 4].Value = totMar;
                    worksheet.Cells[row, 5].Value = totApr;
                    worksheet.Cells[row, 6].Value = totMay;
                    worksheet.Cells[row, 7].Value = totJun;
                    worksheet.Cells[row, 8].Value = totJul;
                    worksheet.Cells[row, 9].Value = totAug;
                    worksheet.Cells[row, 10].Value = totSep;
                    worksheet.Cells[row, 12].Value = totOct;
                    worksheet.Cells[row, 13].Value = totNov;
                    worksheet.Cells[row, 14].Value = GranTotal;
                    worksheet.Cells[row, 1, row, 14].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 1, row, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 1, row, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 1, row, 14].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    reportBytes = package.GetAsByteArray();
                }

                return File(reportBytes, XlsxContentType, "YearlyDistanceReport.xlsx");


            } catch (Exception ex) {
                string messages = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = messages });
            }
        }

        public async Task<IActionResult> GetDistanceMonth(int year, int month) {
            ViewBag.Year = year;
            ViewBag.Month = months.Where(x => x.Id == month).FirstOrDefault().Name;
            ViewBag.M = month;

            var strSql = $"EXEC uspMonthlyDistance {year},{month}";
            var data = await appQuery.MonthlyDistanceAsync<MonthlyDistanceViewModel>(strSql);

            var groupdata = from x in data.ToList()
                            group x by new {
                                x.Years,
                                x.Months,
                                x.RegionName,
                                x.BranchCode,
                                x.BranchName
                            } into g
                            select new {
                                g.Key.Years,
                                g.Key.Months,
                                g.Key.RegionName,
                                g.Key.BranchCode,
                                g.Key.BranchName,
                                PickupKm = g.Sum(x => x.PickupKm),
                                MotocycleKm = g.Sum(x => x.MotocycleKm),
                                SubContactKm = g.Sum(x => x.SubContactKm)
                            };
            //add data to header-items
            var dataModel = from x in groupdata
                            group x by new { x.Years, x.Months, x.RegionName } into g
                            select new HeaderMonthly {
                                RegionName = g.Key.RegionName,
                                Items = (from x in groupdata
                                         where x.RegionName == g.Key.RegionName
                                         select new ItemMonthly {
                                             RegionName = x.RegionName,
                                             BranchCode = x.BranchCode,
                                             BranchName = x.BranchName,
                                             PickupKm = x.PickupKm,
                                             MotorcycleKm = x.MotocycleKm,
                                             SubContactKm = x.SubContactKm
                                         }).ToList()
                            };

            var dictionary = new Dictionary<string, List<ItemMonthly>>();
            foreach (var item in dataModel) {
                dictionary.Add(item.RegionName, item.Items);
            }

            // ViewBag.DistanceMonth = dataModel.ToList();

            return PartialView("_TableDistanceMonth", dictionary);
        }

        public async Task<IActionResult> ExcelDistanceMonth(int year, int month) {
            try {
                var strSql = $"EXEC uspMonthlyDistance {year},{month}";
                var data = await appQuery.MonthlyDistanceAsync<MonthlyDistanceViewModel>(strSql);
                var groupdata = from x in data.ToList()
                                group x by new {
                                    x.Years,
                                    x.Months,
                                    x.RegionName,
                                    x.BranchCode,
                                    x.BranchName
                                } into g
                                select new {
                                    g.Key.Years,
                                    g.Key.Months,
                                    g.Key.RegionName,
                                    g.Key.BranchCode,
                                    g.Key.BranchName,
                                    PickupKm = g.Sum(x => x.PickupKm),
                                    MotocycleKm = g.Sum(x => x.MotocycleKm),
                                    SubContactKm = g.Sum(x => x.SubContactKm)
                                };
                //add data to header-items
                var dataModel = from x in groupdata
                                group x by new { x.Years, x.Months, x.RegionName } into g
                                select new HeaderMonthly {
                                    RegionName = g.Key.RegionName,
                                    Items = (from x in groupdata
                                             where x.RegionName == g.Key.RegionName
                                             select new ItemMonthly {
                                                 RegionName = x.RegionName,
                                                 BranchCode = x.BranchCode,
                                                 BranchName = x.BranchName,
                                                 PickupKm = x.PickupKm,
                                                 MotorcycleKm = x.MotocycleKm,
                                                 SubContactKm = x.SubContactKm
                                             }).ToList()
                                };

                var dictionary = new Dictionary<string, List<ItemMonthly>>();
                foreach (var item in dataModel) {
                    dictionary.Add(item.RegionName, item.Items);
                }

                byte[] reportBytes;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage()) {
                    package.Workbook.Properties.Title = "Monthly Distance Report";
                    package.Workbook.Properties.Author = "Tatthep M.";
                    package.Workbook.Properties.Subject = "Monthly Distance Report";
                    package.Workbook.Properties.Keywords = "Monthly Distance Report";
                    var worksheet = package.Workbook.Worksheets.Add("MonthlyDistanceReport");

                    //First add the headers
                    worksheet.Cells["A1:F1"].Merge = true;
                    worksheet.Cells["A1:F1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1:F1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells["A1"].Value = "เลขระยะทางรวมปี " + $"{year} - เดือน {months.Where(x => x.Id == month).FirstOrDefault().Name}";

                    worksheet.Cells[2, 1].Value = "ภาค";
                    worksheet.Cells[2, 2].Value = "สาขา";
                    worksheet.Cells[2, 3].Value = "ระยะทางรวม รถยนต์";
                    worksheet.Cells[2, 4].Value = "ระยะทางรวม มอเตอร์ไซด์";
                    worksheet.Cells[2, 5].Value = "ระยะทางรวม รถSub";
                    worksheet.Cells[2, 6].Value = "รวม";

                    var row = 3;
                    int totPickup = 0, totMotor = 0, totSub = 0;

                    foreach (var key in dictionary.Keys) {
                        List<ItemMonthly> values;
                        dictionary.TryGetValue(key, out values);
                        totPickup = values.Sum(x => x.PickupKm);
                        totMotor = values.Sum(x => x.MotorcycleKm);
                        totSub = values.Sum(x => x.SubContactKm);
                        foreach (var value in values) {
                            var total = value.PickupKm + value.MotorcycleKm + value.SubContactKm;
                            worksheet.Cells[row, 1].Value = key;
                            worksheet.Cells[row, 2].Value = value.BranchCode;
                            worksheet.Cells[row, 3].Value = value.PickupKm;
                            worksheet.Cells[row, 4].Value = value.MotorcycleKm;
                            worksheet.Cells[row, 5].Value = value.SubContactKm;
                            worksheet.Cells[row, 6].Value = total;

                            worksheet.Cells[row, 1, row, 6].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[row, 1, row, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[row, 1, row, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            worksheet.Cells[row, 1, row, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            row++;
                        }
                    }
                    worksheet.Cells[row, 1, row, 2].Merge = true;
                    worksheet.Cells[row, 1, row, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[row, 1].Value = "รวม";
                    worksheet.Cells[row, 3].Value = totPickup;
                    worksheet.Cells[row, 4].Value = totMotor;
                    worksheet.Cells[row, 5].Value = totSub;
                    worksheet.Cells[row, 6].Value = totPickup + totMotor + totSub;

                    worksheet.Cells[row, 3, row, 6].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    reportBytes = package.GetAsByteArray();
                }
                return File(reportBytes, XlsxContentType, "MonthlyDistanceReport.xlsx");

            } catch (Exception ex) {
                string messages = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new { sms = messages });
            }
        }

        public async Task<IActionResult> GetDistanceByBranchMonth(int year, int month, string branch) {
            var m = month.ToString().Length == 1 ? $"0{month}" : month.ToString();
            var code = $"{m}{year}";

            ViewBag.Year = year;
            ViewBag.Month = months.Where(x => x.Id == month).FirstOrDefault().Name;
            ViewBag.M = month;
            ViewBag.Branch = branch;

            var model = (await app.TruckInspectionCards.QueryAsyncAsNoTracking(x =>
                        x.CardControlCode == code
                        )).ToList()
                        .GroupBy(x => x.VehicleId)
                        .Where(x => x.FirstOrDefault().BranchCode == branch)
                        .Select(x => new MonthlyBranchDistanceViewModel {
                            RegionName = x.FirstOrDefault().RegionName,
                            BranchCode = x.FirstOrDefault().BranchCode,
                            PlateNumber = x.FirstOrDefault().PlateNumber,
                            VehicleType = x.FirstOrDefault().VehicleType,
                            TotalOdometer = x.Sum(x => x.Distance)
                        });

            ViewBag.MonthlyBranch = model;
            var C = model.Count();
            ViewBag.Count = C;
            ViewBag.C = C;
            ViewBag.GrandTotal = model.Sum(x => x.TotalOdometer);

            return PartialView("_TableMonthlyBranch");
        }

        public async Task<IActionResult> ExcecGetDistanceByBranchMonth(int year, int month, string branch) {
            try {
                var m = month.ToString().Length == 1 ? $"0{month}" : month.ToString();
                var code = $"{m}{year}";
                var model = (await app.TruckInspectionCards.QueryAsyncAsNoTracking(x =>
                            x.CardControlCode == code
                            )).ToList()
                            .GroupBy(x => x.VehicleId)
                            .Where(x => x.FirstOrDefault().BranchCode == branch)
                            .Select(x => new MonthlyBranchDistanceViewModel {
                                RegionName = x.FirstOrDefault().RegionName,
                                BranchCode = x.FirstOrDefault().BranchCode,
                                PlateNumber = x.FirstOrDefault().PlateNumber,
                                VehicleType = x.FirstOrDefault().VehicleType,
                                TotalOdometer = x.Sum(x => x.Distance)
                            });

                var GrandTotal = model.Sum(x => x.TotalOdometer);

                byte[] reportBytes;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage()) {
                    package.Workbook.Properties.Title = "Monthly Distance Report";
                    package.Workbook.Properties.Author = "Tatthep M.";
                    package.Workbook.Properties.Subject = "Monthly Distance Report";
                    package.Workbook.Properties.Keywords = "Monthly Distance Report";
                    var worksheet = package.Workbook.Worksheets.Add("MonthlyDistanceReport");

                    //First add the headers
                    worksheet.Cells["A1:E1"].Merge = true;
                    worksheet.Cells["A1:E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1:E1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells["A1"].Value = "เลขระยะทางรวมปี " + $"{year} - เดือน {months.Where(x => x.Id == month).FirstOrDefault().Name}";

                    worksheet.Cells[2, 1].Value = "ภาค";
                    worksheet.Cells[2, 2].Value = "สาขา";
                    worksheet.Cells[2, 3].Value = "ทะเบียน";
                    worksheet.Cells[2, 4].Value = "ประเภทรถ";
                    worksheet.Cells[2, 5].Value = "รวมระยะทางที่รถวิ่ง";

                    var row = 3;
                    foreach (var item in model) {
                        worksheet.Cells[row, 1].Value = item.RegionName;
                        worksheet.Cells[row, 2].Value = item.BranchCode;
                        worksheet.Cells[row, 3].Value = item.PlateNumber;
                        worksheet.Cells[row, 4].Value = item.VehicleType;
                        worksheet.Cells[row, 5].Value = item.TotalOdometer;

                        worksheet.Cells[row, 1, row, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        row++;
                    }

                    worksheet.Cells[row, 1, row, 4].Merge = true;
                    worksheet.Cells[row, 1, row, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[row, 1, row, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; 
                    worksheet.Cells[row, 1].Value = "รวม";
                    worksheet.Cells[row, 5].Value = GrandTotal;

                    worksheet.Cells[row, 3, row, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    reportBytes = package.GetAsByteArray();
                }
                return File(reportBytes, XlsxContentType, "MonthlyBranchDistanceReport.xlsx");

            } catch (Exception ex) {

                string messages = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new { sms = messages });
            }
        }

        public async Task<IActionResult> GetDistanceByBranchDay(DateTime day, string branch) {
            try {
                ViewBag.Day = day;
                ViewBag.BranchCode = branch;
                ViewBag.Date = $"{day:dd/MM/yyyy}";
                var model = (await app.TruckInspectionCards.QueryAsyncAsNoTracking(x =>
                            x.InspectionDate == day && x.BranchCode == branch))
                            .Select(x => new DailyBranchDistanceViewModel {
                                RegionName = x.RegionName,
                                BranchCode = x.BranchCode,
                                BranchName = x.BranchName,
                                PlateNumber = x.PlateNumber,
                                VehicleType = x.VehicleType,
                                StartOdometer = x.StartOdometer,
                                FinishedOdometer = x.FinishedOdometer,
                                TotalOdometer = x.Distance
                            }).ToList();

                ViewBag.GrandTotal = model.Sum(x => x.TotalOdometer);

                var C = model.Count();
                ViewBag.Branch = C == 0 ? null : model.FirstOrDefault().BranchName;
                ViewBag.Count = C;
                ViewBag.C = C;

                ViewBag.DailyBranch = model;

                return PartialView("_TableDailyBranch");

            } catch (Exception ex) {

                string messages = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new { sms = messages });
            }
        }

        public async Task<IActionResult> ExcelGetDistanceByBranchDay(DateTime day, string branch) {
            try {
                var model = (await app.TruckInspectionCards.QueryAsyncAsNoTracking(x =>
                            x.InspectionDate == day && x.BranchCode == branch))
                            .Select(x => new DailyBranchDistanceViewModel {
                                RegionName = x.RegionName,
                                BranchCode = x.BranchCode,
                                BranchName = x.BranchName,
                                PlateNumber = x.PlateNumber,
                                VehicleType = x.VehicleType,
                                StartOdometer = x.StartOdometer,
                                FinishedOdometer = x.FinishedOdometer,
                                TotalOdometer = x.Distance
                            }).ToList();

                var grandTotal = model.Sum(x => x.TotalOdometer);

                byte[] reportBytes;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage()) {
                    package.Workbook.Properties.Title = "Monthly Distance Report";
                    package.Workbook.Properties.Author = "Tatthep M.";
                    package.Workbook.Properties.Subject = "Monthly Distance Report";
                    package.Workbook.Properties.Keywords = "Monthly Distance Report";
                    var worksheet = package.Workbook.Worksheets.Add("MonthlyDistanceReport");

                    //First add the headers
                    worksheet.Cells["A1:G1"].Merge = true;
                    worksheet.Cells["A1:G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1:G1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells["A1"].Value = "รายงานเลขระยะทางวันที่ " + $"{day:dd/MM/yyyy} ประจำสาขา {model.FirstOrDefault().BranchName}";

                    worksheet.Cells[2, 1].Value = "ภาค";
                    worksheet.Cells[2, 2].Value = "สาขา";
                    worksheet.Cells[2, 3].Value = "ทะเบียน";
                    worksheet.Cells[2, 4].Value = "ประเภทรถ";
                    worksheet.Cells[2, 5].Value = "เลขระยะทางเริ่มต้นของวัน";
                    worksheet.Cells[2, 6].Value = "เลขระยะทางสิ้นสุดของวัน";
                    worksheet.Cells[2, 7].Value = "รวมระยะทางที่รถวิ่งในวัน";

                    var row = 3;
                    foreach (var item in model) {
                        worksheet.Cells[row, 1].Value = item.RegionName;
                        worksheet.Cells[row, 2].Value = item.BranchCode;
                        worksheet.Cells[row, 3].Value = item.PlateNumber;
                        worksheet.Cells[row, 4].Value = item.VehicleType;
                        worksheet.Cells[row, 5].Value = item.StartOdometer;
                        worksheet.Cells[row, 6].Value = item.FinishedOdometer;
                        worksheet.Cells[row, 7].Value = item.TotalOdometer;

                        worksheet.Cells[row, 1, row, 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[row, 1, row, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        row++;
                    }

                    worksheet.Cells[row, 1, row, 6].Merge = true;
                    worksheet.Cells[row, 1, row, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[row, 1, row, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[row, 1].Value = "รวม";
                    worksheet.Cells[row, 7].Value = grandTotal;

                    worksheet.Cells[row, 3, row, 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row, 3, row, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    reportBytes = package.GetAsByteArray();
                }
                return File(reportBytes, XlsxContentType, "DailyBranchDistanceReport.xlsx");



            } catch (Exception ex) {
                string messages = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new { sms = messages });

            }
        }
    }

    internal class Month {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
