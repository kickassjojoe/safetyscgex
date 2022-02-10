using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc {
    public class Util {
        private readonly App app;

        public Util(App app) => this.app = app;

        public async Task<string> NextCode(string prefix, string description, int digitRunning, bool isAddPrefix) {

            var l = await app.LogNumbers.FindAsync(prefix);
            if (l != null) {
                var compareToday = l.UpdateDate.CompareTo(DateTime.Today);
                if (compareToday == 0) {
                    var max = l.GetMax(prefix);
                    l.MaxNumber = ++max;
                    l.Description = description;
                    l.UpdateDate = DateTime.Today;

                    await app.LogNumbers.UpdateAsync(l);
                    await app.SaveChangesAsync();

                    return GetAutoCode(prefix, max, digitRunning, isAddPrefix);
                }
            }

            var logNumber = new LogNumber(prefix, description, 1);
            await app.LogNumbers.AddAsync(logNumber);
            await app.SaveChangesAsync();

            return GetAutoCode(prefix, 1, digitRunning, isAddPrefix);
        }

        private string GetAutoCode(string prefix, int maxNumber, int digitRunning, bool isAddPrefix) {
            var sb = new StringBuilder();
            sb.Clear();
            if (isAddPrefix) {
                sb.Append(prefix);
            };

            sb.Append(maxNumber.ToString().PadLeft(digitRunning, '0'));
            return sb.ToString();
        }
       
    }
}
