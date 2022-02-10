using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Mvc.Models;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers {
    [Authorize]
    public class PartSixesController : Controller {
        private readonly App app;

        public PartSixesController(App app) {
            this.app = app;
        }

        public async Task<IActionResult> Index(string sms, string branchCode) {
            //  DateTime? from, DateTime? to
            // ViewBag.From = from == null ? DateTime.Today : from;
            // ViewBag.To = to == null ? DateTime.Today : to;

            TempData["Msg"] = sms;
            var branches = await app.Branches.AllAsyncAsNoTracking();
            ViewBag.Branches = new SelectList(branches.Select(x => new { Id = x.BranchCode, Name = x.BranchCode }), "Id", "Name");
            await GetInvestigate(branchCode);

            return View();
        }

        public async Task<IActionResult> GetInvestigate(string branchCode) {
            //DateTime datefrom, DateTime dateto
            //ViewBag.From = datefrom;
            //ViewBag.To = dateto;
            //var data = (await app.InvestigateCards.QueryAsync(x => x.InvestigateStatusCode == "100" &&
            //  (datefrom <= x.CreatedDate.Date && x.CreatedDate.Date <= dateto))).ToList();

            ViewBag.BranchCode = branchCode;

            var data = (await app.InvestigateCards.QueryAsync(x => x.InvestigateStatusCode == "100")).ToList();
            if (!String.IsNullOrWhiteSpace(branchCode)) {
                data = data.Where(x => x.PartOne.BranchCode == branchCode).ToList();
            }

            return PartialView("pv_Table", data);
        }

        public async Task<IActionResult> Delete(Guid id) {
            using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try {
                var item = await app.InvestigateCards.FindAsync(id);
                if (item == null) {
                    return RedirectToAction(nameof(Index), new { sms = "Data not found." });
                }

                var logEmployee = await app.LogEmployees.FindAsync(item.PartOne.EmployeeCode);
                var previousDamage = (int)item.PartTwo.TruckDamage == 2;

                await app.LogEmployees.UpdateCaseDelete(logEmployee, previousDamage);

                await app.InvestigateCards.RemoveAsync(item);
                await app.SaveChangesAsync();

                scope.Complete();

                return Json(new { message = "DeleteOK" });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new { sms = message });

            }
        }

        public async Task<IActionResult> OpenPartSix(Guid id, string branchCode, string sms, string createOrEdit, int previousDamage) {
            TempData["Msg"] = sms;

            ViewBag.InvestigateCardId = id;
            ViewBag.BranchCode = branchCode;
            ViewBag.CreateOrEdit = createOrEdit;
            ViewBag.Previous = previousDamage;

            var investigate = await app.InvestigateCards.FindAsync(id);
            var items = investigate.PartFive.PartFiveDetails.Count();
            if (items == 0) {
                return RedirectToAction(nameof(Index), new { sms = "ไม่พบข้อมูลส่วนที่1-5" });
            }

            var codes = new string[] { "216", "311", "619", "813", "915" };

            var model = investigate.PartFive.PartFiveDetails.Select(x => new PartSixViewModel {
                UnsafeItemCode = x.UnsafeItemCode,
                UnsafeItemName = codes.Contains(x.UnsafeItemCode) ? x.Description : x.UnsafeItem.Name,
                UnsafeType = x.UnsafeItem.UnsafeCategory.UnsafeType.ToString(),
                PersonResponse = $"{investigate.PartOne.BranchCode}-Leader"
            });

            return await Task.Run(() => View(model.OrderBy(x => x.UnsafeType).ToList()));
        }

        [HttpPost]
        public async Task<IActionResult> AddPartSix(string[] solution,
                                                    string[] unsafeItemCode,
                                                    string[] unsafeItemName,
                                                    string[] presonResponse,
                                                    DateTime[] solutionDate,
                                                    Guid investigateCardId,
                                                    string branchCode,
                                                    string createOrEdit,
                                                    int previousDamage) {
            try {
                List<PartSix> partSixes = new List<PartSix>();
                for (int i = 0; i < solution.Length; i++) {
                    PartSix partSix = new PartSix() {
                        UnsafeItemCode = unsafeItemCode[i],
                        UnsafeItemName = unsafeItemName[i],
                        Solution = solution[i],
                        ResponsePerson = presonResponse[i],
                        DueDate = solutionDate[i]
                    };

                    partSixes.Add(partSix);
                }

                var investigateCard = await app.InvestigateCards.FindAsync(investigateCardId);
                investigateCard.InvestigateStatusCode = "200";
                investigateCard.PartSixes = partSixes;

                //create penalty notice
                int unsafePoints = 0;
                string casetype = investigateCard.PartOne.CaseType.ToString();

                List<PenaltyNoticeDetail> penaltyNoticeDetails = new List<PenaltyNoticeDetail>();

                if (casetype == "ผิด" || casetype == "ประมาทร่วม") {
                    //create penalty notice
                    string[] unsafeItems = new string[investigateCard.PartFive.PartFiveDetails.Count];

                    int index = 0;
                    var codes = new string[] { "216", "311", "619", "813", "915" };

                    foreach (var item in investigateCard.PartFive.PartFiveDetails) {
                        PenaltyNoticeDetail pd = new PenaltyNoticeDetail() {
                            Name = codes.Contains(item.UnsafeItemCode) ? item.Description : item.UnsafeItem.Name
                        };
                        unsafeItems[index] = item.UnsafeItemCode;
                        penaltyNoticeDetails.Add(pd);
                        index++;
                    }

                    unsafePoints = (await app.UnsafeItems.QueryAsyncAsNoTracking(x => unsafeItems.Contains(x.UnsafeItemCode))).Sum(x => x.DeductPoint);


                    var empCode = investigateCard.PartOne.EmployeeCode;
                    var pnCode = await app.PenaltyNotices.GenCode();

                    var deductPointId = (int)investigateCard.PartOne.Rank;
                    var deductPoint = await app.DeductPoints.FindAsync(1);

                    var isDamage = (int)investigateCard.PartTwo.TruckDamage == 2;

                    var prefixCaseName = "";//fullCaseName[0];
                    var suffixCaseName = 0;// Convert.ToInt32(fullCaseName[1]);

                    //
                    var logEmployee = await app.LogEmployees.FindAsync(empCode);
                    if (logEmployee == null) {
                        var _log = await app.LogEmployees.AddLog(empCode, isDamage);
                        prefixCaseName = $"1/{ DateTime.Today.Year + 543}";
                        suffixCaseName = _log.IncaseOfDeduction;
                    } else {
                        var isPreviousDamage = previousDamage == 2;
                        var _log = await app.LogEmployees.UpdateLog(
                            item: logEmployee,
                            isDamage: isDamage,
                            previousDamage: isPreviousDamage,
                            action: createOrEdit);

                        suffixCaseName = _log.IncaseOfDeduction;
                    }

                    //
                    var _deductMoneyUnsafe = 0m;
                    if (!investigateCard.PartOne.IsSub) {
                        _deductMoneyUnsafe = unsafePoints > 0 ? 500m : 0m;
                    };

                    var penaltyNotice = new PenaltyNotice() {
                        PenaltyNoticeCode = pnCode,
                        EmployeeCode = empCode,
                        EmployeeName = investigateCard.PartOne.EmployeeName,
                        BranchCode = investigateCard.PartOne.BranchCode,
                        BranchName = investigateCard.PartOne.BranchName,
                        IncidentDescription = investigateCard.PartFour.IncidentRoad.Name,
                        CaseDate = investigateCard.PartOne.CaseDate,
                        CaseCount = prefixCaseName, //wordCount[0],
                        DeductDescription = deductPoint.DeductDescription,
                        TruckDamageDescription = investigateCard.PartTwo.TruckDamageDescription,
                        Warning = deductPoint.Warning,
                        DeductPointAccident = deductPoint.Point,
                        //  DeductMoneyAccident = damage == 2 ? 500m : 0m,
                        DeductPointUnsafe = unsafePoints,
                        DeductMoneyUnsafe = _deductMoneyUnsafe, //unsafePoints > 0 ? 500m : 0m,
                        CreatedBy = User.Identity.Name,
                        InvestigateCardId = investigateCardId,
                        Items = penaltyNoticeDetails
                    };

                    //กำหนดบทลงโทษ ครั้งที่ 1=>500, 2=>1000, 3=>1500
                    penaltyNotice.SetDeductAccident(
                        time: suffixCaseName,
                        isSub: investigateCard.PartOne.IsSub);

                    await app.PenaltyNotices.AddAsync(penaltyNotice);

                }

                await app.InvestigateCards.UpdateAsync(investigateCard);
                await app.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new {
                    sms = "Successfully",
                    branchCode
                });

            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new {
                    sms = message
                });
            }
        }
    }
}
