using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class RegionService : ServiceBase<Region> {
        private readonly App app;

        public RegionService(App app) : base(app) {
            this.app = app;
        }

        public async override Task<Region> RemoveAsync(Region item) {
            item.IsDeleted = true;
            item.DeletedDate = app.Now();

            return await Task.FromResult(item);
        }

        public async override Task<IQueryable<Region>> QueryAsync(Expression<Func<Region, bool>> criteria) {
            var result = base.QueryAsync(criteria).Result.Where(x => !x.IsDeleted);
            return await Task.FromResult(result);
        }
    }
}
