using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class EmployeeService : ServiceBase<Employee> {
        private readonly App app;

        public EmployeeService(App app) : base(app) {
            this.app = app;
            //
        }

        public async Task<string> GenCode() {
            //SUB21010001 SUB{year}{month}0001
            //local functin call NewCode
            string NewCode(string preifx, int maxNumber, int totalWidth) {
                var sb = new StringBuilder();
                sb.Clear();
                sb.Append(preifx);
                sb.Append(maxNumber.ToString().PadLeft(totalWidth, '0'));
                return sb.ToString();
            }

            var lognumber = await app.db.LogNumbers.FindAsync("SUB");
            if (lognumber != null) {
                var max = lognumber.GetMax("SUB");
                var currentMonth = $"{DateTime.Now:yyMM}";
                var logMonth = $"{lognumber.UpdateDate:yyMM}";

                var compareMonth = currentMonth.CompareTo(logMonth);
                lognumber.MaxNumber = compareMonth == 0 ? ++max : 1;
                lognumber.Description = "Shipment";
                lognumber.UpdateDate = DateTime.Today;

                await app.LogNumbers.UpdateAsync(lognumber);
                await app.SaveChangesAsync();

                if (compareMonth == 0) {
                    return NewCode($"SUB{DateTime.Today:yyMM}",
                                 max,
                                 4);
                } else {
                    return NewCode($"SUB{DateTime.Today:yyMM}",
                            1,
                            4);
                }
            }

            var logNumber = new LogNumber("SUB", "Shipment", 1);
            await app.LogNumbers.AddAsync(logNumber);
            await app.SaveChangesAsync();

            return NewCode($"SUB{DateTime.Today:yyMM}",
                         1,
                         4);
        }
    }
}
