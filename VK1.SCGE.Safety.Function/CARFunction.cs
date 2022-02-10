using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Transactions;
using VK1.SCGE.Safety.Function.ViewModels;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Function {
    public class CARFunction {
        private readonly FunctionDb db;
        private readonly Util util;
        private readonly ILog _log;

        public CARFunction(FunctionDb db, Util util,ILog _log) {
            this.db = db;
            this.util = util;
            this._log = _log;
        }

     //   [FunctionName("RunAtFirst")]
        public async Task RunAtFirst([TimerTrigger("0 19 11 5 * *")] TimerInfo myTime, Microsoft.Extensions.Logging.ILogger log) {
            try {
                var from = new DateTime(2020, 11, 1);
                var to = new DateTime(2020, 11, 30);

                var data = await CARViews(from, to);

                if (data.Count == 0) {
                    await _log.WriteAsync($"{DateTime.Now} : ช่วงวันที่1-7 ไม่มีรายการผิดปกติ");
                    return;
                }

                var result = (await CreateCAR(data)).ToString();

                await _log.WriteAsync($"{DateTime.Now} : สร้างใบCAR ช่วงวันที่1-7 สำเร็จ จำนวน {result} ใบ ");

                log.LogInformation($"{DateTime.Now} => {result}");

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                log.LogInformation($"Exception => {message}");

            }
        }

      //  [FunctionName("RunAtEighth")]
        public async Task RunAtEighth([TimerTrigger("0 57 9 14 * *")] TimerInfo myTime, Microsoft.Extensions.Logging.ILogger log) {
            try {
                var from = new DateTime(2020, 9, 1);
                var to = new DateTime(2020, 9, 20);

                var data = await CARViews(from, to);

                var result = (await CreateCAR(data)).ToString();

                log.LogInformation($"{DateTime.Now} => {result}");

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                log.LogInformation($"Exception => {message}");

            }
        }

        public async Task<List<CARViewModel>> CARViews(DateTime from, DateTime to) {
            var strSql = $"EXEC [dbo].[uspCARView] '{from}','{to}'";
            var result = (await db.QuerySqlAsync<CARViewModel>(strSql)).ToList();

            return result;
        }

        public async Task<int> CreateCAR(List<CARViewModel> data) {
            #region Group Header
            var headers = from x in data
                         group x by new {
                             x.PlateNumber,
                             x.VehicleId,
                             x.VehicleType,
                             x.BranchCode,
                             x.BranchName
                         } into g select new CorrectiveActionRequestDto {
                             VehicleId = g.Key.VehicleId,
                             PlateNumber = g.Key.PlateNumber,
                             VehicleType = g.Key.VehicleType,
                             BranchCode = g.Key.BranchCode,
                             BranchName = g.Key.BranchName
                         };
            #endregion
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                try {
                    foreach (var header in headers) {
                        var car = new CorrectiveActionRequest();
                        var gencode = await util.NextCode("SHECAR", "Corrective action requested code", 3, true);
                        car.CARCode = $"{gencode.Substring(0, 6)}{DateTime.Now:ddMMyyyy}{gencode.Substring(6, 3)}";
                        car.Created = DateTime.Today;
                        car.CreatedBy = "System";
                        car.VehicleType = header.VehicleType == "Pickup" ? VehicleType.Pickup : VehicleType.Motorcycle;
                        car.PlateNumber = header.PlateNumber;
                        car.VehicleId = header.VehicleId;
                        car.BranchCode = header.BranchCode;
                        car.BranchName = header.BranchName;
                        car.CARStatusCode = "100";
                        car.CARStatusName = "Created";

                        await db.CorrectiveActionRequests.AddAsync(car);

                        var items = data.Where(x =>
                                    x.VehicleId == header.VehicleId
                                    && x.PlateNumber == header.PlateNumber
                                    && x.BranchCode == header.BranchCode);
                        foreach (var item in items) {
                            var carItem = new CorrectiveActionRequestItem();
                            carItem.CARCode = car.CARCode;
                            carItem.TruckInspectionCardDetailId = item.TruckInspectionCardDetailId;
                            carItem.TruckInspectionCategoryId = item.TruckInspectionCategoryId;
                            carItem.TruckInspectionCategoryName = item.Category;
                            carItem.TruckInspectionItemId = item.TruckInspectionItemId;
                            carItem.TruckInspectionItemName = item.Name;
                            carItem.IsFixed = false;
                            carItem.IssuedDate =Convert.ToDateTime(item.CreatedDate);

                            await db.CorrectiveActionRequestItems.AddAsync(carItem);
                        }
                    }
                    await db.SaveChangesAsync();

                    scope.Complete();

                    return headers.Count();

                } catch (Exception ex) {
                    string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    throw new Exception(message);
                }
            }
        }
    }
}

