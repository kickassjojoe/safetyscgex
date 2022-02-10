using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers.Reports {
    public class DashboardYearlyController : Controller {
        private readonly App app;
        private readonly Util util;
        private readonly AppQuery appQuery;
        private readonly string[] months = new string[] { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        public DashboardYearlyController(App app, Util util, AppQuery appQuery) {
            this.app = app;
            this.util = util;
            this.appQuery = appQuery;
        }

        public async Task<List<Region>> Regions() => (await app.Regions.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Branch>> Branches() => (await app.Branches.AllAsyncAsNoTracking()).ToList();



        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.ActiveMenu = "Dashboard";

            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name");

            ViewBag.Branches = new SelectList((await Branches()).Select(x => new { Id = x.BranchCode, Name = x.BranchCode }), "Id", "Name");

            // GlobalData.InvestigateCards = await GetAll();

            return View();
        }

        public async Task<IActionResult> GetBranch(int id) {

            var data = await app.Branches.AllAsyncAsNoTracking();
            if (id != 0) {
                data = data.Where(x => x.RegionId == id);
            }

            return Json((data.Select(x => new { Id = x.BranchCode, Name = x.BranchCode }).ToList()));
        }

        private async Task<IEnumerable<InvestigateCard>> GetAll(int year, int regionId, string branchCode) {
            IEnumerable<InvestigateCard> data = (await app.InvestigateCards.QueryAsync(x => x.PartOne.CaseDate.Year == year)).AsEnumerable();

            if (regionId != 0) {
                data = data.Where(x => x.PartOne.RegionId == regionId);
            }
            if (!String.IsNullOrEmpty(branchCode)) {
                data = data.Where(x => x.PartOne.BranchCode == branchCode);
            }

            return data;
        }

        public async Task<IActionResult> SummaryByCaseType(int year, int regionId, string branchCode) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);
                // ถูก = 1, ผิด = 2,ประมาทร่วม = 3
                var model = (from x in data
                             group x by new {
                                 x.PartOne.CaseDate.Year,
                                 CompanyName = x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express" ? "รถบริษัท" : "รถผู้รับเหมา",
                                 IsRightSide = x.PartOne.CaseType.ToString() == "ถูก"
                             } into g
                             select new CaseTypeViewModel {
                                 Name = g.Key.CompanyName,
                                 IsRightSide = g.Key.IsRightSide,
                                 CountOfCase = g.Count()
                             }).AsEnumerable();

                ViewBag.CaseTypes = model;

                return PartialView("pv_CaseType");

            } catch (Exception ex) {
                string errors = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw;
            }
        }

        public async Task<IActionResult> SummaryByVehicleType(int year, int regionId, string branchCode) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);
                //var motorcycle = data.Count(x => (int)x.PartOne.TransportBy == 2);
                //var pickup = data.Count(x => (int)x.PartOne.TransportBy != 2);

                var model = from x in data
                            group x by new {
                                Name = (int)x.PartOne.TransportBy == 2 ? "รถจักรยานยนต์" : "รถยนต์"
                            } into g
                            select new IncidentViewModel {
                                Name = g.Key.Name,
                                CountOfCase = g.Count()
                            };

                var chartdata = new object[model.Count() + 1];
                chartdata[0] = new string[] { "ประเภทรถ", "จำนวนครั้ง" };
                int index = 1;
                foreach (var item in model) {
                    chartdata[index] = new object[] { item.Name, item.CountOfCase };
                    index++;
                }
                //chartdata[1] = new object[] { "รถยนต์", pickup };
                //chartdata[2] = new object[] { "รถจักรยานยนต์", motorcycle };

                var region = await app.Regions.FindAsync(regionId);
                var result = new {
                    chartdata,
                    year,
                    region = region?.Name,
                    branchCode
                };
                return Json(result);

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);

            }
        }

        public async Task<IActionResult> SummaryByRank(int year, int regionId, string branchCode) {
            try {

                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);
                #region L0
                var L0 = data.Count(x => (int)x.PartOne.Rank == 1);
                var l0Scg = data.Count(x => (int)x.PartOne.Rank == 1 && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express"));
                var l0Carrier = L0 - l0Scg;
                #endregion

                #region L1
                var L1 = data.Count(x => (int)x.PartOne.Rank == 2);
                var l1Scg = data.Count(x => (int)x.PartOne.Rank == 2 && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express"));
                var l1Carrier = L1 - l1Scg;
                #endregion

                #region L2
                var L2 = data.Count(x => (int)x.PartOne.Rank == 3);
                var l2Scg = data.Count(x => (int)x.PartOne.Rank == 3 && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express"));
                var l2Carrier = L2 - l2Scg;
                #endregion

                #region L3
                var L3 = data.Count(x => (int)x.PartOne.Rank == 4 || (int)x.PartOne.Rank == 5);
                var l3Scg = data.Count(x => ((int)x.PartOne.Rank == 4 || (int)x.PartOne.Rank == 5) && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express"));
                var l3Carrier = L3 - l3Scg;
                #endregion

                List<RankViewModel> rankViewModels = new List<RankViewModel>() {
                    new RankViewModel {Name="เล็กน้อยไม่เข้าเกณฑ์",Scg=l0Scg,Carrier=l0Carrier},
                    new RankViewModel {Name="L1",Scg=l1Scg,Carrier=l1Carrier},
                    new RankViewModel {Name="L2",Scg=l2Scg,Carrier=l2Carrier},
                    new RankViewModel {Name="L3",Scg=l3Scg,Carrier=l3Carrier},
                };

                ViewBag.Ranks = rankViewModels;

                return PartialView("pv_Rank");

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);

            }
        }

        public async Task<IActionResult> SummaryByAccidentMode(int year, int regionId, string branchCode) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);
                //var transport = data.Count(x => (int)x.PartOne.AccidentMode == 1);
                //var other = data.Count(x => (int)x.PartOne.AccidentMode == 2);
                var model = from x in data
                            group x by new {
                                Name = x.PartOne.AccidentMode.ToString()
                            } into g
                            select new IncidentViewModel {
                                Name = g.Key.Name,
                                CountOfCase = g.Count()
                            };

                var chartdata = new object[model.Count() + 1];
                chartdata[0] = new string[] { "ประเภทอุบัติเหตุ", "จำนวนครั้ง" };
                int index = 1;
                foreach (var item in model) {
                    chartdata[index] = new object[] { item.Name, item.CountOfCase };
                    index++;
                }
                //chartdata[1] = new object[] { "Transport", transport };
                //chartdata[2] = new object[] { "Other", other };

                var region = await app.Regions.FindAsync(regionId);
                var result = new {
                    chartdata,
                    year,
                    region = region?.Name,
                    branchCode
                };

                return Json(result);

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);
            }

        }

        public async Task<IActionResult> SummaryByIncident(int year, int regionId, string branchCode) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);

                var model1 = from x in data
                             group x by x.PartFour.IncidentRoad.Name into g
                             select new IncidentViewModel {
                                 Name = g.Key,
                                 CountOfCase = g.Count()
                             };

                var chartdata = new object[model1.Count() + 1];
                chartdata[0] = new string[] { "ลักษณะอุบัติเหตุ", "จำนวนครั้ง" };
                int idx = 1;
                foreach (var item in model1) {
                    chartdata[idx] = new object[] { item.Name, item.CountOfCase };
                    idx++;
                };

                var region = await app.Regions.FindAsync(regionId);
                var result = new {
                    chartdata,
                    year,
                    region = region?.Name,
                    branchCode
                };

                return Json(result);

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);
            }
        }

        public async Task<IActionResult> MonthlyTransportScg(int year, int regionId, string branchCode) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 1 && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Month = x.PartOne.CaseDate.Month,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Month,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Month);
                if (model.Count() > 0) {

                    List<MonthlyAccidentViewModel> viewModels = new List<MonthlyAccidentViewModel>();

                    for (int i = 1; i < 13; i++) {
                        MonthlyAccidentViewModel item = new MonthlyAccidentViewModel();
                        item.Month = months[i];

                        var result = model.Where(x => x.Month == i).ToList();
                        if (result != null) {
                            //
                            var right = result.Where(x => x.CaseType == "ถูก").FirstOrDefault();
                            item.RightSide = right == null ? 0 : right.CountOfCase;
                            //
                            var wrong = result.Where(x => x.CaseType == "ผิด").FirstOrDefault();
                            item.WrongSide = wrong == null ? 0 : wrong.CountOfCase;
                        }

                        viewModels.Add(item);

                    }

                    var chartData = new object[13];
                    //["Month", "ถูก", "ผิด"],
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Month, obj.RightSide, obj.WrongSide };
                        idx++;
                    }

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);
                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);
                }

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);
            }

        }

        public async Task<IActionResult> MonthlyTransportCarrier(int year, int regionId, string branchCode) {
            try {

                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);

                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 1 && !(x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Month = x.PartOne.CaseDate.Month,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Month,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Month);

                if (model.Count() > 0) {

                    List<MonthlyAccidentViewModel> viewModels = new List<MonthlyAccidentViewModel>();

                    for (int i = 1; i < 13; i++) {
                        MonthlyAccidentViewModel item = new MonthlyAccidentViewModel();
                        item.Month = months[i];

                        var result = model.Where(x => x.Month == i).ToList();
                        if (result != null) {
                            //
                            var right = result.Where(x => x.CaseType == "ถูก").FirstOrDefault();
                            item.RightSide = right == null ? 0 : right.CountOfCase;
                            //
                            var wrong = result.Where(x => x.CaseType == "ผิด").FirstOrDefault();
                            item.WrongSide = wrong == null ? 0 : wrong.CountOfCase;
                        }

                        viewModels.Add(item);

                    }

                    var chartData = new object[13];
                    //["Month", "ถูก", "ผิด"],
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Month, obj.RightSide, obj.WrongSide };
                        idx++;
                    }

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);
                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);
                }

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);
            }

        }

        public async Task<IActionResult> SummaryByTransport(int year, string regionId, string branchCode) {
            try {
                regionId ??= "%";
                branchCode ??= "%";

                var strSql = $"EXEC MonthlyAccidentTransport {year},'{regionId}','{branchCode}'";

                var model = (await appQuery.MonthlyAccidentTransportAsync<MonthlyAccidentTransportViewModel>(strSql)).ToArray();

                var dataRows = new object[2];
                if (model.Length == 2) {
                    for (int i = 0; i < model.Length; i++) {
                        dataRows[i] = new object[] {
                            model[i].CaseType,
                            model[i].January??=0,
                            model[i].February??=0,
                            model[i].March??=0,
                            model[i].April??=0,
                            model[i].May??=0,
                            model[i].June??=0,
                            model[i].July??=0,
                            model[i].August??=0,
                            model[i].September??=0,
                            model[i].October??=0,
                            model[i].November??=0,
                            model[i].December??=0
                        };
                    }
                } else if (model.Length == 1) {
                    var isCaseType = model[0].CaseType == "ถูก";
                    dataRows[0] = new object[] {
                            model[0].CaseType=isCaseType?"ถูก":"ผิด",
                            model[0].January??=0,
                            model[0].February??=0,
                            model[0].March??=0,
                            model[0].April??=0,
                            model[0].May??=0,
                            model[0].June??=0,
                            model[0].July??=0,
                            model[0].August??=0,
                            model[0].September??=0,
                            model[0].October??=0,
                            model[0].November??=0,
                            model[0].December??=0
                        };
                    dataRows[1] = new object[] { !isCaseType ? "ถูก" : "ผิด", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                } else {
                    dataRows[0] = new object[] { "ถูก", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    dataRows[1] = new object[] { "ผิด", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                }

                return Json(dataRows);

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);
            }
        }

        public async Task<IActionResult> MonthlyOtherScg(int year, int regionId, string branchCode) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 2 && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Month = x.PartOne.CaseDate.Month,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Month,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Month);

                if (model.Count() > 0) {

                    List<MonthlyAccidentViewModel> viewModels = new List<MonthlyAccidentViewModel>();

                    for (int i = 1; i < 13; i++) {
                        MonthlyAccidentViewModel item = new MonthlyAccidentViewModel();
                        item.Month = months[i];

                        var result = model.Where(x => x.Month == i).ToList();
                        if (result != null) {
                            //
                            var right = result.Where(x => x.CaseType == "ถูก").FirstOrDefault();
                            item.RightSide = right == null ? 0 : right.CountOfCase;
                            //
                            var wrong = result.Where(x => x.CaseType == "ผิด").FirstOrDefault();
                            item.WrongSide = wrong == null ? 0 : wrong.CountOfCase;
                        }

                        viewModels.Add(item);

                    }

                    var chartData = new object[13];
                    //["Month", "ถูก", "ผิด"],
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Month, obj.RightSide, obj.WrongSide };
                        idx++;
                    }

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);
                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);
                }

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };

                return Json(result);
            }
        }

        public async Task<IActionResult> MonthlyOtherCarrier(int year, int regionId, string branchCode) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(year, regionId, branchCode);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 2 && !(x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Month = x.PartOne.CaseDate.Month,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Month,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Month);

                if (model.Count() > 0) {

                    List<MonthlyAccidentViewModel> viewModels = new List<MonthlyAccidentViewModel>();

                    for (int i = 1; i < 13; i++) {
                        MonthlyAccidentViewModel item = new MonthlyAccidentViewModel();
                        item.Month = months[i];

                        var result = model.Where(x => x.Month == i).ToList();
                        if (result != null) {
                            //
                            var right = result.Where(x => x.CaseType == "ถูก").FirstOrDefault();
                            item.RightSide = right == null ? 0 : right.CountOfCase;
                            //
                            var wrong = result.Where(x => x.CaseType == "ผิด").FirstOrDefault();
                            item.WrongSide = wrong == null ? 0 : wrong.CountOfCase;
                        }

                        viewModels.Add(item);

                    }

                    var chartData = new object[13];
                    //["Month", "ถูก", "ผิด"],
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Month, obj.RightSide, obj.WrongSide };
                        idx++;
                    }

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);

                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Month", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        year,
                        region = region?.Name,
                        branchCode
                    };

                    return Json(_result);
                }

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };

                return Json(result);
            }
        }

        public async Task<IActionResult> SummaryByOther(int year, string regionId, string branchCode) {
            try {
                regionId ??= "%";
                branchCode ??= "%";

                var strSql = $"EXEC MonthlyAccidentOther {year},'{regionId}','{branchCode}'";

                var model = (await appQuery.MonthlyAccidentTransportAsync<MonthlyAccidentTransportViewModel>(strSql)).ToArray();

                var dataRows = new object[2];
                if (model.Length == 2) {
                    for (int i = 0; i < model.Length; i++) {
                        dataRows[i] = new object[] {
                            model[i].CaseType,
                            model[i].January??=0,
                            model[i].February??=0,
                            model[i].March??=0,
                            model[i].April??=0,
                            model[i].May??=0,
                            model[i].June??=0,
                            model[i].July??=0,
                            model[i].August??=0,
                            model[i].September??=0,
                            model[i].October??=0,
                            model[i].November??=0,
                            model[i].December??=0
                        };
                    }
                } else if (model.Length == 1) {
                    var isCaseType = model[0].CaseType == "ถูก";
                    dataRows[0] = new object[] {
                            model[0].CaseType=isCaseType?"ถูก":"ผิด",
                            model[0].January??=0,
                            model[0].February??=0,
                            model[0].March??=0,
                            model[0].April??=0,
                            model[0].May??=0,
                            model[0].June??=0,
                            model[0].July??=0,
                            model[0].August??=0,
                            model[0].September??=0,
                            model[0].October??=0,
                            model[0].November??=0,
                            model[0].December??=0
                        };
                    dataRows[1] = new object[] { !isCaseType ? "ถูก" : "ผิด", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                } else {
                    dataRows[0] = new object[] { "ถูก", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    dataRows[1] = new object[] { "ผิด", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                }

                return Json(dataRows);

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);
            }
        }
    }
}