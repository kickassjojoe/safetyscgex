using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Mvc.Models.ReportViewModels;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers.Reports {
    public class TruckInspectionReportsController : Controller {
        private readonly App app;
        private readonly AppQuery appQuery;
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public TruckInspectionReportsController(App app, AppQuery appQuery) {
            this.app = app;
            this.appQuery = appQuery;
        }

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.ActiveMenu = "Dashboard";

            var regions = (await app.Regions.AllAsyncAsNoTracking()).Select(x => new {
                Id = x.RegionId,
                x.Name
            });
            ViewBag.Regions = new SelectList(regions, "Id", "Name");

            var branches = (await app.Branches.AllAsyncAsNoTracking()).Select(x => new {
                Id = x.BranchCode,
                x.Name
            });
            ViewBag.Branches = new SelectList(branches, "Id", "Name");


            return View();
        }

        public async Task<IActionResult> GetAll(string dateFrom, string dateTo, string regionId, string branchCode) {
            try {
                regionId ??= "%";
                branchCode ??= "%";

                ViewBag.DateFrom = dateFrom;
                ViewBag.DateTo = dateTo;
                ViewBag.RegionId = regionId;
                ViewBag.BranchCode = branchCode;

                var model = await GetData(dateFrom, dateTo, regionId, branchCode);

                ViewBag.Count = model.Count();

                return PartialView("_Table", model);

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }
        }

        public async Task<IEnumerable<TruckInspectionReportModel>> GetData(string dateFrom, string dateTo, string regionId, string branchCode) {

            var strSql = $"EXEC dbo.uspTruckInspectionReport '{dateFrom}','{dateTo}','{regionId}','{branchCode}'";

            var data = await appQuery.TruckInspectionReportAsync<TruckInspectionReportViewModel>(strSql);
            var result = data.ToList();
            var model = from x in result group x by x.RegionId into g1
                        select new TruckInspectionReportModel {
                            RegionId = g1.Key,
                            RegionName = g1.FirstOrDefault().RegionName,
                            Branches = (
                                        from x in result
                                        group x by x.BranchCode into g2
                                        where g2.FirstOrDefault().RegionId == g1.FirstOrDefault().RegionId
                                        select new TruckInspectionReportBranch {
                                            RegionId = g1.Key,
                                            BranchCode = g2.Key,
                                            BranchName = g2.FirstOrDefault().BranchName,
                                            Vehicles = (
                                               from x in result
                                               group x by x.VehicleId into g3
                                               where g2.Key == g3.FirstOrDefault().BranchCode
                                               select new TruckInspectionReortVehicle {
                                                   BranchCode = g2.Key,
                                                   VehicleId = g3.Key,
                                                   PlateNumber = g3.FirstOrDefault().PlateNumber,
                                                   Items = (
                                                   from x in result
                                                   where x.VehicleId == g3.Key
                                                   select new TruckInspectionReportItem {
                                                       VehicleId = g3.Key,
                                                       Name = x.Name,
                                                       Category = x.Category,
                                                       CreatedDate = x.CreatedDate
                                                   }
                                                   ).ToList()
                                               }
                                            ).ToList()
                                        }).ToList()
                        };

            return model;
        }

        public async Task<IActionResult> ExportExcel(string dateFrom, string dateTo, string regionId, string branchCode) {
            try {
                var from = Convert.ToDateTime(dateFrom);
                var to = Convert.ToDateTime(dateTo);

                var data = (await GetData(dateFrom, dateTo, regionId, branchCode)).ToList();

                byte[] reportBytes;

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage()) {
                    package.Workbook.Properties.Title = "Truck Inspection Report";
                    package.Workbook.Properties.Author = "Tatthep M.";
                    package.Workbook.Properties.Subject = "Truck Inspection Report";
                    package.Workbook.Properties.Keywords = "Truck Inspection Report";
                    var worksheet = package.Workbook.Worksheets.Add("TruckInspectionReport");

                    //First add the headers
                    worksheet.Cells["A1:F1"].Merge = true;
                    worksheet.Cells["A1:F1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A1"].Value = "รายงานการตรวจสภาพรถ";
                    worksheet.Cells["A2:F2"].Merge = true;
                    worksheet.Cells["A2:F2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A2"].Value = "ระหว่างวันที่ " + $"{from:dd/MM/yyyy}" + " ถึงวันที่ " + $"{to:dd/MM/yyyy}";

                    worksheet.Cells[3, 1].Value = "ภาค";
                    worksheet.Cells[3, 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[3, 2].Value = "สาขา";
                    worksheet.Cells[3, 2].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[3, 3].Value = "ทะเบียนรถ";
                    worksheet.Cells[3, 3].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[3, 4].Value = "รายการผิดปรกติ";
                    worksheet.Cells[3, 4].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[3, 5].Value = "";
                    worksheet.Cells[3, 5].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    worksheet.Cells[3, 6].Value = "วันที่ตรวจพบ";
                    worksheet.Cells[3, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                    var row = 4;

                    foreach (var region in data) {
                        worksheet.Cells[row, 1].Value = region.RegionName;
                        foreach (var branch in region.Branches) {
                            worksheet.Cells[row, 2].Value = branch.BranchName;
                            foreach (var vehicle in branch.Vehicles) {
                                worksheet.Cells[row, 3].Value = vehicle.PlateNumber;
                                foreach (var item in vehicle.Items) {
                                    worksheet.Cells[row, 4].Value = item.Category;
                                    worksheet.Cells[row, 5].Value = item.Name;
                                    worksheet.Cells[row, 6].Value = item.CreatedDate;
                                    worksheet.Cells[row, 6].Style.Numberformat.Format = "dd-mm-yyyy";

                                    // set style
                                    worksheet.Cells[row, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[row, 1, row, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                                    row++;
                                }
                            }
                        }
                        worksheet.Cells[row, 1, row, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }

                    reportBytes = package.GetAsByteArray();
                }

                return File(reportBytes, XlsxContentType, "TruckInspectionReport.xlsx");

            } catch (Exception ex) {
                string messages = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = messages });
            }
        }
    }
}
