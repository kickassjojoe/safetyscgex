using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Services;
using System.Linq;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Function {
    public class CoolCustomerFunction {
        private readonly MySqlQuery mySqlQuery;
        private readonly App app;

        public CoolCustomerFunction(MySqlQuery mySqlQuery, App app) {
            this.mySqlQuery = mySqlQuery;
            this.app = app;
        }

        [FunctionName("CoolCustomerFunction")]
        public async Task CoolCustomer([TimerTrigger("0 43 8 * * *")] TimerInfo myTimer, ILogger log) {
            var parcel = (await app.Parcels.AllAsyncAsNoTracking()).ToList();
            await app.Parcels.BulkDeleteAsync(parcel);

            var sql = "select * from cool_customer_monitoring";
            var data = await mySqlQuery.CoolCustomers<CoolCustomerViewModel>(sql);

            var result = (from x in data select new Parcel {
                Type = x.Type,
                RegionName = x.RegionName,
                Month = Convert.ToInt32(x.Month),
                Date = x.Date,
                NewCustomerQty = (int)x.NewCustomerQty,
                OldCustomerQty = (int)x.OldCustomerQty,
                NewOrderQty = (int)x.NewOrderQty,
                OldOrderQty = (int)x.OldOrderQty
            }).ToList();

            await app.Parcels.BulkInsert(result);

            await app.SaveChangesAsync();
            
            log.LogInformation($"Cool C# Timer trigger function executed at: {DateTime.Now} {result.Count} records");

        }
    }
}
