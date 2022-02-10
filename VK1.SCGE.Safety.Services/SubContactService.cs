using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class SubContactService : ServiceBase<SubContact> {
        private readonly App app;

        public SubContactService(App app) : base(app) {
            this.app = app;
        }

        public override async Task<IQueryable<SubContact>> QueryAsync(Expression<Func<SubContact, bool>> criteria) {
            return (await base.QueryAsync(criteria)).Where(x => !x.IsDeleted);
        }
    }
}
