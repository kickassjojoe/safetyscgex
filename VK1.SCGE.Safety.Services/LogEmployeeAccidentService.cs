using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class LogEmployeeAccidentService : ServiceBase<LogEmployeeAccident> {
        private readonly App app;

        public LogEmployeeAccidentService(App app) : base(app) {
            this.app = app;
            //
        }

        public async Task<LogEmployeeAccident> AddLog(string employeeCode, bool isDamage) {
            var logEmployeeAccident = new LogEmployeeAccident();

            logEmployeeAccident.EmployeeCode = employeeCode;

            logEmployeeAccident.SetMaxNumber();

            logEmployeeAccident.SetIncaseOfDeductionCreate(isDamage);

            await app.LogEmployees.AddAsync(logEmployeeAccident);
            await app.SaveChangesAsync();

            return logEmployeeAccident;
        }

        public async Task<LogEmployeeAccident> UpdateLog(LogEmployeeAccident item, bool isDamage,bool previousDamage,string action) {
            if (action == "create") {
                item.SetMaxNumber();
            }
            item.SetIncaseOfDedcutionEdit(isDamage,previousDamage);
            item.UpdateDate = DateTime.Today;

            await app.LogEmployees.UpdateAsync(item);
            await app.SaveChangesAsync();

            return item;

        }

        public async Task<LogEmployeeAccident> UpdateCaseDelete(LogEmployeeAccident item ,bool previousDamage) {
            item.SetCaseDelete(previousDamage);
            item.UpdateDate = DateTime.Today;

            await app.LogEmployees.UpdateAsync(item);
            await app.SaveChangesAsync();

            return item;
        }
    }
}
