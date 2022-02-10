using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {

    [Authorize]
    public class ImportExcelController : Controller {
        private readonly App app;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ImportExcelController(App app, IWebHostEnvironment webHostEnvironment) {
            this.app = app;
            this.webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> Branch() {
            try {
                byte[] byteexcel = System.IO.File.ReadAllBytes(@"D:\\PROJECT\\EXPRESS\\Document\\Branch.xlsx");
                int totalRow = 0;

                using (var memoryStream = new MemoryStream(byteexcel)) {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(memoryStream)) {
                        var worksheet = package.Workbook.Worksheets["branch"]; // Tip: To access the first worksheet, try index 1, not 0
                        var rowCount = worksheet.Dimension?.Rows;
                        List<Branch> branches = new List<Branch>();
                        for (int row = 2; row < rowCount.Value; row++) {
                            Branch item = new Branch();
                            item.BranchCode = worksheet.Cells[row, 1].Value.ToString();
                            item.Name = worksheet.Cells[row, 2].Value.ToString();
                            item.CreatedBy = "0900-000011";
                            item.CreatedDate = DateTime.Now;

                            branches.Add(item);
                            totalRow++;
                        }

                        await app.Branches.BulkInsert(branches);
                        await app.SaveChangesAsync();

                    }

                }

                var message = $"Insert {totalRow} สำเร็จ";
                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });
            }
        }

        public async Task<IActionResult> Vehicle() {
            try {

                byte[] byteexcel = System.IO.File.ReadAllBytes(@"D:\\PROJECT\\EXPRESS\\Document\\Vehicle.xlsx");
                int totalRow = 0;

                using (var memoryStream = new MemoryStream(byteexcel)) {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(memoryStream)) {
                        var worksheet = package.Workbook.Worksheets["vehicle"]; // Tip: To access the first worksheet, try index 1, not 0

                        var rowCount = worksheet.Dimension?.Rows;

                        List<Vehicle> vehicles = new List<Vehicle>();

                        for (int row = 2; row < rowCount.Value; row++) {
                            int compare = VehicleType.Pickup.ToString().CompareTo(worksheet.Cells[row, 7].Value.ToString());

                            Vehicle item = new Vehicle();
                            item.PlateNumber = worksheet.Cells[row, 2].Value.ToString();
                            item.RegionName = worksheet.Cells[row, 3].Value.ToString();
                            item.BranchCode = worksheet.Cells[row, 4].Value.ToString();
                            item.Brand = worksheet.Cells[row, 5].Value.ToString();
                            item.GpsProvider = worksheet.Cells[row, 6].Value.ToString();
                            item.VehicleType = compare == 0 ? VehicleType.Pickup : VehicleType.Motorcycle;
                            item.RegionId = Convert.ToInt32(worksheet.Cells[row, 8].Value.ToString());
                            item.CreatedBy = "0900-000011";
                            item.CreatedDate = DateTime.Now;

                            vehicles.Add(item);
                            totalRow++;
                        }

                        await app.Vehicles.BulkInsert(vehicles);
                        await app.SaveChangesAsync();

                    }

                }

                var message = $"Insert {totalRow} สำเร็จ";

                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });
            }
        }

        public async Task<IActionResult> TruckInspectionItem() {
            try {

                byte[] byteexcel = System.IO.File.ReadAllBytes(@"D:\\PROJECT\\EXPRESS\\Document\\TruckInspectionItem.xlsx");
                int totalRow = 0;

                using (var memoryStream = new MemoryStream(byteexcel)) {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(memoryStream)) {
                        var worksheet = package.Workbook.Worksheets["Sheet1"]; // Tip: To access the first worksheet, try index 1, not 0

                        var rowCount = worksheet.Dimension?.Rows;

                        List<TruckInspectionItem> truckInspectionItems = new List<TruckInspectionItem>();

                        for (int row = 2; row < rowCount.Value; row++) {

                            TruckInspectionItem item = new TruckInspectionItem();

                            item.Name = worksheet.Cells[row, 2].Value.ToString();
                            item.TruckInspectionCategoryId = Convert.ToInt32(worksheet.Cells[row, 3].Value.ToString());
                            item.IsMust = Convert.ToBoolean(worksheet.Cells[row, 4].Value.ToString());
                            item.IsFirstAndFifteenth = Convert.ToBoolean(worksheet.Cells[row, 5].Value.ToString());
                            item.CreatedBy = "0900000011";
                            item.CreatedDate = DateTime.Now;

                            truckInspectionItems.Add(item);
                            totalRow++;
                        }

                        await app.TruckInspectionItems.BulkInsert(truckInspectionItems);
                        await app.SaveChangesAsync();

                    }

                }

                var message = $"Insert {totalRow} สำเร็จ";

                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });
            }
        }

        public async Task<IActionResult> Parcel() {
            try {
                byte[] byteexcel = System.IO.File.ReadAllBytes(@"D:\\PROJECT\\EXPRESS\\Document\\ParcelTemplate.xlsx");
                int totalRow = 0;

                using (var memoryStream = new MemoryStream(byteexcel)) {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(memoryStream)) {
                        var worksheet = package.Workbook.Worksheets["sheet1"]; // Tip: To access the first worksheet, try index 1, not 0
                        var rowCount = worksheet.Dimension?.Rows;
                        List<Parcel> parcels = new List<Parcel>();
                        for (int row = 2; row <= rowCount.Value; row++) {
                            Parcel item = new Parcel();
                            item.RegionName = worksheet.Cells[row, 1].Value.ToString();
                            item.Month = Convert.ToInt32(worksheet.Cells[row, 2].Value.ToString());
                            item.Date = Convert.ToDateTime(worksheet.Cells[row, 3].Value.ToString()); ;
                            item.NewCustomerQty = Convert.ToInt32(worksheet.Cells[row, 4].Value.ToString());
                            item.OldCustomerQty = Convert.ToInt32(worksheet.Cells[row, 5].Value.ToString());
                            item.NewOrderQty = Convert.ToInt32(worksheet.Cells[row, 6].Value.ToString());
                            item.OldOrderQty = Convert.ToInt32(worksheet.Cells[row, 7].Value.ToString());
                            item.Type = worksheet.Cells[row, 8].Value.ToString();

                            parcels.Add(item);
                            totalRow++;
                        }

                        await app.Parcels.BulkInsert(parcels);
                        await app.SaveChangesAsync();

                    }

                }

                var message = $"Insert {totalRow} สำเร็จ";
                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(HomeController.Index), "Home", new { sms = message });
            }
        }
    }
}
