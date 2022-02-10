using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers.Reports {
    public class TestsController : Controller {
        private readonly MySqlQuery mySqlQuery;

        public TestsController(MySqlQuery mySqlQuery) {
            this.mySqlQuery = mySqlQuery;
        }

        public async Task<IActionResult> Index() {
            var sql = "select organization_id,name from tbl_organization limit 10";
            var data = await mySqlQuery.Test<TestMySqlViewModel>(sql);

            return View();
        }
    }
}
