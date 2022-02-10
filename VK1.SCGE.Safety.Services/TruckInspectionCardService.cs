using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class TruckInspectionCardService : ServiceBase<TruckInspectionCard> {
        private readonly App app;

        public TruckInspectionCardService(App app) : base(app) {
            this.app = app;
        }

        public async override Task<TruckInspectionCard> AddAsync(TruckInspectionCard item) {
            item.CreatedDate = app.Now();
            return await base.AddAsync(item);
        }


    }
}
