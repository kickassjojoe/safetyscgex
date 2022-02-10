using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Services.Data;

namespace VK1.SCGE.Safety.Services {
    public class MySqlQuery {
        private readonly MySqlQueryDb mySqlQueryDb;

        public MySqlQuery(MySqlQueryDb mySqlQueryDb) {
            this.mySqlQueryDb = mySqlQueryDb;
        }

        public async Task<List<TestMySqlViewModel>> Test<T>(string sql) => (await mySqlQueryDb.QuerySqlAsync<TestMySqlViewModel>(sql)).ToList();

        public async Task<List<CoolCustomerViewModel>> CoolCustomers<T>(string sql) => (await mySqlQueryDb.QuerySqlAsync<CoolCustomerViewModel>(sql)).ToList();
    }
}
