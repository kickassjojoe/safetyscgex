using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Function {
    public class Util {
        private readonly FunctionDb db;
        public Util(FunctionDb db) => this.db = db;

        public async Task<string> NextCode(string prefix, string description, int digitRunning, bool isAddPrefix) {

            var l = await db.LogNumbers.FindAsync(prefix);
            if (l != null) {
                var compareToday = l.UpdateDate.CompareTo(DateTime.Today);
                var max = compareToday == 0 ? l.GetMax(prefix) : 1;
                l.MaxNumber = compareToday == 0 ? ++max : max;
                l.Description = description;
                l.UpdateDate = DateTime.Today;

                db.LogNumbers.Update(l);
                await db.SaveChangesAsync();
                return GetAutoCode(prefix, max, digitRunning, isAddPrefix);
            }

            var logNumber = new LogNumber(prefix, description, 1);
            await db.LogNumbers.AddAsync(logNumber);
            await db.SaveChangesAsync();

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
