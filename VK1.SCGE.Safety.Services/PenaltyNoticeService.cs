using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {

    public class PenaltyNoticeService : ServiceBase<PenaltyNotice> {
        private readonly App app;

        public PenaltyNoticeService(App app) : base(app) {
            this.app = app;
            //
        }

        public async Task<string> GenCode() {

            var lognumber = await app.db.LogNumbers.FindAsync("PN");

            if (lognumber != null) {

                var isEqualtoDate = lognumber.UpdateDate.Date.CompareTo(DateTime.Today);

                var max = lognumber.GetMax("PN");
                lognumber.Description = "Penalty Notice";
                lognumber.MaxNumber = isEqualtoDate == 0 ? ++max : 1;
                lognumber.UpdateDate = DateTime.Today;

                await app.LogNumbers.UpdateAsync(lognumber);
                await app.SaveChangesAsync();

                return $"{DateTime.Today:ddMMyy}-{max}";
            }

            var newLog = new LogNumber() {
                Prefix = "PN",
                Description = "Penalty Notice",
                MaxNumber = 1,
                UpdateDate = DateTime.Today
            };

            await app.LogNumbers.AddAsync(newLog);
            await app.SaveChangesAsync();

            return $"{DateTime.Today:ddMMyy}-1";
        }
    }
}
