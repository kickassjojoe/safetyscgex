using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class InvestigateCardService : ServiceBase<InvestigateCard>, IInvestigateService {
        private readonly App app;

        public InvestigateCardService(App app) : base(app) {
            this.app = app;
            //
        }

        public async Task<PartOne> AddPartOneAsync(PartOne item) {
            var _result = await app.db.Set<PartOne>().AddAsync(item);
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<PartOne> result = await Task.FromResult(_result);

            return result.Entity;
        }

        public async Task<PartTwo> AddPartTwoAsync(PartTwo item) {
            var _result = await app.db.Set<PartTwo>().AddAsync(item);
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<PartTwo> result = await Task.FromResult(_result);

            return result.Entity;
        }
    }
}
