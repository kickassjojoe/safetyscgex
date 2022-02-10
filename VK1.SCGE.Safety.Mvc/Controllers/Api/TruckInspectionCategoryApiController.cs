using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers.Api {
    [Route("api/[controller]")]
    [ApiController]
    public class TruckInspectionCategoryApiController : ControllerBase {
        private readonly App app;

        public TruckInspectionCategoryApiController(App app) {
            this.app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Categories() {
            try {
                var result = await app.TruckInspectionCategories.AllAsync();

                return Ok(result);

            } catch (Exception) {

                throw new Exception("Computer say no");
            }
        }
    }
}
