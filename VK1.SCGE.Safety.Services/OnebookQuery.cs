using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Services.Data;

namespace VK1.SCGE.Safety.Services {
    public class OnebookQuery {
        private readonly OnebookQueryDb db;

        public OnebookQuery(OnebookQueryDb db) {
            this.db = db;
        }

        //employee view
        public async Task<IQueryable<EmployeeViewModel>> ViewEmployeeAsync<T>(string strSql) {
            return await db.QuerySqlAsync<EmployeeViewModel>(strSql);
        }

       
    }
}
