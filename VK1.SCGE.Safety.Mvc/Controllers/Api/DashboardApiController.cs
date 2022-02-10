using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Controllers.Api {
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardApiController : ControllerBase {

        [HttpGet("summaryByVehicleType")]
        public IActionResult SummaryByVehicleType() {
            try {
                var data = new object[3];
                data[0] = new string[] { "ประเภทรถ", "จำนวนครั้ง" };
                data[1] = new object[] { "รถยนต์", 10 };
                data[2] = new object[] { "รถจักรยานยนต์", 4 };

                return Ok(data);

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return StatusCode(500, error);

            }
        }
    }
}
