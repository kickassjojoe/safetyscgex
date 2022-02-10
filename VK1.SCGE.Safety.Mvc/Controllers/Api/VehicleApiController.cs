using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleApiController : ControllerBase {
        private readonly App app;

        public VehicleApiController(App app) {
            this.app = app;
        }

        [HttpGet]
        public async Task<IActionResult> Vehicles() {
            var vehicles = await app.Vehicles.AllAsyncAsNoTracking();
            if (vehicles == null) {
                return NotFound();
            }

            var result = vehicles.Where(x => !x.IsUse).Select(x => new {
                x.Id,
                Text = x.PlateNumber
            }).OrderBy(x => x.Id);

            return Ok(result);
        }

    }
}
