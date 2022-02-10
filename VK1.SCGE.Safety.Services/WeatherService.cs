using System;
using System.Collections.Generic;
using System.Text;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class WeatherService : ServiceBase<Weather> {
        public WeatherService(App app) : base(app) {
            //
        }
    }
}
