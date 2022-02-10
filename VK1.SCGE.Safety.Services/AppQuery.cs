using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Services.Data;

namespace VK1.SCGE.Safety.Services {
   public class AppQuery {
        private readonly AppQueryDb db;

        public AppQuery(AppQueryDb db) {
            this.db = db;
        }

        //truckinspection report
        public async Task<IQueryable<TruckInspectionReportViewModel>> TruckInspectionReportAsync<T>(string strSql) {
            return await db.QuerySqlAsync<TruckInspectionReportViewModel>(strSql);
        }

        public async Task<IQueryable<YearlyDistanceViewModel>> YearlyDistanceAsync<T>(string strSql) {
            return await db.QuerySqlAsync<YearlyDistanceViewModel>(strSql);
        }

        public async Task<IQueryable<MonthlyDistanceViewModel>> MonthlyDistanceAsync<T>(string strSql) {
            return await db.QuerySqlAsync<MonthlyDistanceViewModel>(strSql);
        }

        public async Task<IQueryable<MonthlyAccidentTransportViewModel>> MonthlyAccidentTransportAsync<T>(string strSql) {
            return await db.QuerySqlAsync<MonthlyAccidentTransportViewModel>(strSql);
        }
    }
}
