using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class TruckInspectionItemService : ServiceBase<TruckInspectionItem> {
        private readonly App app;

        public TruckInspectionItemService(App app) : base(app) {
            this.app = app;
            //
        }

        public async override Task<IQueryable<TruckInspectionItem>> AllAsync() {
            return await QueryAsync(x => true);
        }

        public async override Task<IQueryable<TruckInspectionItem>> QueryAsync(Expression<Func<TruckInspectionItem, bool>> criteria) {
            var result = base.QueryAsync(criteria).Result.Where(x => !x.IsDeleted);

            return await Task.FromResult(result);
        }

        public async override Task<TruckInspectionItem> RemoveAsync(TruckInspectionItem item) {
            item.IsDeleted = true;
            item.DeletedDate =  app.Now();
            return await Task.FromResult(item);
        }

    }
}
