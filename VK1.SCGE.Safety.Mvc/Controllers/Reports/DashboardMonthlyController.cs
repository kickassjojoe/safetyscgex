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
    public class DashboardMonthlyController : Controller {
        private readonly App app;
        private readonly AppQuery appQuery;
        private readonly Util util;
        private readonly string[] months = new string[] { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private readonly string[] thaimonths = new string[] { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
        private struct ThaiMonth {
            public int id;
            public string name;
        }
        private List<ThaiMonth> GetThaiMonths {
            get {
                List<ThaiMonth> months = new List<ThaiMonth>();
                for (int i = 1; i <= 12; i++) {
                    ThaiMonth thaiMonth;
                    thaiMonth.id = i;
                    thaiMonth.name = thaimonths[i - 1];
                    months.Add(thaiMonth);
                }
                return months;
            }
        }

        public async Task<List<Region>> Regions() => (await app.Regions.AllAsyncAsNoTracking()).ToList();

        public DashboardMonthlyController(App app, AppQuery appQuery, Util util) {
            this.app = app;
            this.appQuery = appQuery;
            this.util = util;
        }

        public async Task<IActionResult> Index() {
            ViewBag.ThaiMonths = new SelectList(GetThaiMonths.Select(x => new { Id = x.id, Name = x.name }), "Id", "Name");

            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name");

            return View();
        }

        private async Task<IEnumerable<InvestigateCard>> GetAll(int month, int regionId) {
            IEnumerable<InvestigateCard> data = (await app.InvestigateCards.QueryAsync(
                x => x.PartOne.CaseDate.Year == DateTime.Now.Year
                && x.PartOne.CaseDate.Month == month)).AsEnumerable();

            if (regionId != 0) {
                data = data.Where(x => x.PartOne.RegionId == regionId);
            }

            return data;
        }

        public async Task<IActionResult> SummaryByCaseType(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                var c = data.Count();
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

        public async Task<IActionResult> SummaryByVehicleType(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
               // var motorcycle = data.Count(x => (int)x.PartOne.TransportBy == 2);
               // var pickup = data.Count(x => (int)x.PartOne.TransportBy != 2);

                var model = from x in data
                            group x by new {
                                Name = (int)x.PartOne.TransportBy == 2 ? "รถจักรยานยนต์" : "รถยนต์"
                            } into g
                            select new IncidentViewModel {
                                Name = g.Key.Name,
                                CountOfCase = g.Count()
                            };

                var chartdata = new object[model.Count()+1];
                chartdata[0] = new string[] { "ประเภทรถ", "จำนวนครั้ง" };
                int index = 1;
                foreach (var item in model) {
                    chartdata[index] = new object[] { item.Name, item.CountOfCase };
                    index++;
                }

                //chartdata[1] = new object[] { "รถยนต์", pickup };
               // chartdata[2] = new object[] { "รถจักรยานยนต์", motorcycle };

                var region = await app.Regions.FindAsync(regionId);
                var result = new {
                    chartdata,
                    month = thaimonths[month - 1],
                    region = region?.Name,
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

        public async Task<IActionResult> SummaryByRank(int month, int regionId) {
            try {

                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
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

        public async Task<IActionResult> SummaryByAccidentMode(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                // var transport = data.Count(x => (int)x.PartOne.AccidentMode == 1);
                // var other = data.Count(x => (int)x.PartOne.AccidentMode == 2);

                var model = from x in data
                            group x by new {
                                Name = x.PartOne.AccidentMode.ToString()
                            } into g
                            select new IncidentViewModel {
                                Name = g.Key.Name,
                                CountOfCase = g.Count()
                            };

                var chartdata = new object[model.Count()+1];
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
                    month = thaimonths[month - 1],
                    region = region?.Name,
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

        public async Task<IActionResult> SummaryByIncident(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);

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
                    month = thaimonths[month - 1],
                    region = region?.Name,
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

        public async Task<IActionResult> RegionTransportScg(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 1 && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Region = x.PartOne.RegionName,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Region,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Region).ToList();

                if (model.Count > 0) {

                    var groupRegion = from x in model
                                      group x by x.Region into g select g.Key;

                    List<RegionAccidentViewModel> viewModels = new List<RegionAccidentViewModel>();
                    foreach (var r in groupRegion) {
                        RegionAccidentViewModel viewModel = new RegionAccidentViewModel();
                        viewModel.Region = r;

                        var rowData = model.Where(x => x.Region == r);
                        foreach (var item in rowData) {
                            viewModel.RightSide = item.CaseType == "ถูก" ? item.CountOfCase : 0;
                            viewModel.WrongSide = item.CaseType == "ผิด" ? item.CountOfCase : 0;
                        }

                        viewModels.Add(viewModel);
                    }

                    var chartData = new object[viewModels.Count + 1];
                    //["Month", "ถูก", "ผิด"],
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Region, obj.RightSide, obj.WrongSide };
                        idx++;
                    }

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
                    };

                    return Json(_result);
                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
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

        public async Task<IActionResult> RegionTransportCarrier(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 1 && !(x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Region = x.PartOne.RegionName,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Region,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Region).ToList();

                if (model.Count > 0) {
                    //
                    var groupRegion = from x in model
                                      group x by x.Region into g select g.Key;

                    List<RegionAccidentViewModel> viewModels = new List<RegionAccidentViewModel>();
                    foreach (var r in groupRegion) {
                        RegionAccidentViewModel viewModel = new RegionAccidentViewModel();
                        viewModel.Region = r;

                        var rowData = model.Where(x => x.Region == r);
                        foreach (var item in rowData) {
                            viewModel.RightSide = item.CaseType == "ถูก" ? item.CountOfCase : 0;
                            viewModel.WrongSide = item.CaseType == "ผิด" ? item.CountOfCase : 0;
                        }

                        viewModels.Add(viewModel);
                    }

                    //

                    var chartData = new object[viewModels.Count + 1];
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Region, obj.RightSide, obj.WrongSide };
                        idx++;
                    }
                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
                    };

                    return Json(_result);

                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
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

        public async Task<IActionResult> SummaryByTransport(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 1
                             group x by new {
                                 Region = x.PartOne.RegionName,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Region,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Region).ToArray();

                var chartData = new object[3];
                if (model.Length > 0) {

                    var groupRegion = from x in model
                                      group x by x.Region into g select g.Key;

                    string[] arrRegion = new string[groupRegion.Count() + 1];
                    object[] arrRight = new object[groupRegion.Count() + 1];
                    object[] arrWrong = new object[groupRegion.Count() + 1];
                    arrRegion[0] = "Region";
                    arrRight[0] = "ถูก";
                    arrWrong[0] = "ผิด";

                    int index = 1;
                    foreach (var regionName in groupRegion) {

                        arrRegion[index] = regionName;

                        var rowData = model.Where(x => x.Region == regionName);
                        foreach (var item in rowData) {
                            arrRight[index] = item.CaseType == "ถูก" ? item.CountOfCase : 0;
                            arrWrong[index] = item.CaseType == "ผิด" ? item.CountOfCase : 0;
                        }

                        index++;

                    }

                    chartData[0] = arrRegion;
                    chartData[1] = arrRight;
                    chartData[2] = arrWrong;
                } else {
                    chartData[0] = new object[] { "Region", "No Data" };
                    chartData[1] = new object[] { "ถูก", 0 };
                    chartData[2] = new object[] { "ผิด", 0 };
                }

                return Json(chartData);

            } catch (Exception ex) {
                var error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "",
                    Error = error
                };
                return Json(result);
            }
        }

        public async Task<IActionResult> RegionOtherScg(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 2 && (x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Region = x.PartOne.RegionName,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Region,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Region).ToList();

                if (model.Count > 0) {
                    //
                    var groupRegion = from x in model
                                      group x by x.Region into g select g.Key;

                    List<RegionAccidentViewModel> viewModels = new List<RegionAccidentViewModel>();
                    foreach (var r in groupRegion) {
                        RegionAccidentViewModel viewModel = new RegionAccidentViewModel();
                        viewModel.Region = r;

                        var rowData = model.Where(x => x.Region == r);
                        foreach (var item in rowData) {
                            viewModel.RightSide = item.CaseType == "ถูก" ? item.CountOfCase : 0;
                            viewModel.WrongSide = item.CaseType == "ผิด" ? item.CountOfCase : 0;
                        }

                        viewModels.Add(viewModel);
                    }
                    //
                    var chartData = new object[viewModels.Count + 1];
                    //["Month", "ถูก", "ผิด"],
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Region, obj.RightSide, obj.WrongSide };
                        idx++;
                    }
                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
                    };

                    return Json(_result);
                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
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

        public async Task<IActionResult> RegionOtherCarrier(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 2 && !(x.PartOne.CompanyName == "SCG Skill" || x.PartOne.CompanyName == "SCG Express")
                             group x by new {
                                 Region = x.PartOne.RegionName,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Region,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Region).ToList();

                if (model.Count > 0) {
                    //
                    var groupRegion = from x in model
                                      group x by x.Region into g select g.Key;

                    List<RegionAccidentViewModel> viewModels = new List<RegionAccidentViewModel>();
                    foreach (var r in groupRegion) {
                        RegionAccidentViewModel viewModel = new RegionAccidentViewModel();
                        viewModel.Region = r;

                        var rowData = model.Where(x => x.Region == r);
                        foreach (var item in rowData) {
                            viewModel.RightSide = item.CaseType == "ถูก" ? item.CountOfCase : 0;
                            viewModel.WrongSide = item.CaseType == "ผิด" ? item.CountOfCase : 0;
                        }

                        viewModels.Add(viewModel);
                    }
                    //
                    var chartData = new object[viewModels.Count + 1];
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    int idx = 1;
                    foreach (var obj in viewModels) {
                        chartData[idx] = new object[] { obj.Region, obj.RightSide, obj.WrongSide };
                        idx++;
                    }
                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
                    };

                    return Json(_result);

                } else {
                    var chartData = new object[2];
                    chartData[0] = new object[] { "Region", "ถูก", "ผิด" };
                    chartData[1] = new object[] { "No Data", 0, 0 };

                    var region = await app.Regions.FindAsync(regionId);
                    var _result = new {
                        chartData,
                        month = thaimonths[month - 1],
                        region = region?.Name,
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

        public async Task<IActionResult> SummaryByOther(int month, int regionId) {
            try {
                IEnumerable<InvestigateCard> data = await GetAll(month, regionId);
                var model = (from x in data
                             where (int)x.PartOne.AccidentMode == 2
                             group x by new {
                                 Region = x.PartOne.RegionName,
                                 CaseType = (int)x.PartOne.CaseType == 1 ? "ถูก" : "ผิด"
                             } into g
                             select new {
                                 g.Key.Region,
                                 g.Key.CaseType,
                                 CountOfCase = g.Count()
                             }).OrderBy(x => x.Region).ToArray();

                var chartData = new object[3];
                if (model.Length > 0) {

                    var groupRegion = from x in model
                                      group x by x.Region into g select g.Key;

                    string[] arrRegion = new string[groupRegion.Count() + 1];
                    object[] arrRight = new object[groupRegion.Count() + 1];
                    object[] arrWrong = new object[groupRegion.Count() + 1];
                    arrRegion[0] = "Region";
                    arrRight[0] = "ถูก";
                    arrWrong[0] = "ผิด";

                    int index = 1;
                    foreach (var regionName in groupRegion) {

                        arrRegion[index] = regionName;

                        var rowData = model.Where(x => x.Region == regionName);
                        foreach (var item in rowData) {
                            arrRight[index] = item.CaseType == "ถูก" ? item.CountOfCase : 0;
                            arrWrong[index] = item.CaseType == "ผิด" ? item.CountOfCase : 0;
                        }

                        index++;

                    }

                    chartData[0] = arrRegion;
                    chartData[1] = arrRight;
                    chartData[2] = arrWrong;
                } else {
                    chartData[0] = new object[] { "Region", "No Data" };
                    chartData[1] = new object[] { "ถูก", 0 };
                    chartData[2] = new object[] { "ผิด", 0 };
                }

                return Json(chartData);

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
