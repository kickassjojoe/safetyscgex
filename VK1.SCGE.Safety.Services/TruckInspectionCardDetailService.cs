using System;
using System.Collections.Generic;
using System.Text;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class TruckInspectionCardDetailService : ServiceBase<TruckInspectionCardDetail> {
        private readonly App app;
        public TruckInspectionCardDetailService(App app) : base(app) {
            this.app = app;
        }



    }
}
