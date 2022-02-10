using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Mvc.Dtos;
using VK1.SCGE.Safety.Services;


namespace VK1.SCGE.Safety.Mvc.Controllers {

    [Authorize]
    public class InvestigatesController : Controller {
        private readonly App app;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string[] imagetype = new string[] {
            "image/jpeg",
            "image/png",
            "image/tiff",
            "image/webp"
        };

        public InvestigatesController(App app, IWebHostEnvironment webHostEnvironment) {
            this.app = app;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<Branch>> Branches() => (await app.Branches.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Employee>> Employees() => (await app.Employees.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Vehicle>> Vehicles() => (await app.Vehicles.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Region>> Regions() => (await app.Regions.AllAsyncAsNoTracking()).ToList();
        public async Task<List<IncidentTruck>> IncidentTrucks() => (await app.IncidentTrucks.AllAsyncAsNoTracking()).ToList();
        public async Task<List<IncidentTruckPositon>> IncidentTruckPositons() => (await app.IncidentTruckPositons.AllAsyncAsNoTracking()).ToList();
        public async Task<List<IncidentArea>> IncidentAreas() => (await app.IncidentAreas.AllAsyncAsNoTracking()).ToList();
        public async Task<List<IncidentRoad>> IncidentRoads() => (await app.IncidentRoads.AllAsyncAsNoTracking()).ToList();
        public async Task<List<AreaCondition>> AreaConditions() => (await app.AreaConditions.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Weather>> Weathers() => (await app.Weathers.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Traffic>> Traffics() => (await app.Traffics.AllAsyncAsNoTracking()).ToList();
        public async Task<List<IncidentDepot>> IncidentDepots() => (await app.IncidentDepots.AllAsyncAsNoTracking()).ToList();
        public async Task<List<UnsafeCategory>> UnsafeCategories() => (await app.UnsafeCategories.AllAsync()).ToList();
        public async Task<List<UnsafeItem>> UnsafeItems() => (await app.UnsafeItems.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Position>> Positions() => (await app.Positoins.AllAsyncAsNoTracking()).ToList();
        public async Task<List<Carrier>> Carriers() => (await app.Carries.AllAsyncAsNoTracking()).ToList();

        public async Task<IActionResult> Index(string sms) {
            TempData["Msg"] = sms;
            ViewBag.Accident = "Accident";

            ViewBag.Branches = new SelectList((await Branches()).Select(x => new { Id = x.BranchCode, x.Name }), "Id", "Name");

            //ViewBag.Employees = new SelectList((await Employees()).Select(x => new { Id = x.EmployeeCode, Name = x.NameTH }), "Id", "Name");

            ViewBag.Vehicles = new SelectList((await Vehicles()).Select(x => new { x.Id, Name = x.PlateNumber }), "Id", "Name");

            ViewBag.Regions = new SelectList((await Regions()).Select(x => new { Id = x.RegionId, x.Name }), "Id", "Name");

            //part foure
            ViewBag.IncidentTrucks = new SelectList((await IncidentTrucks()).Select(x => new { Id = x.IncidentTruckId, x.Name }), "Id", "Name");

            ViewBag.IncidentTruckPositons = new SelectList((await IncidentTruckPositons()).Select(x => new { Id = x.IncidentTruckPositonId, x.Name }), "Id", "Name");

            ViewBag.IncidentAreas = new SelectList((await IncidentAreas()).Select(x => new { Id = x.IncidentAreaId, x.Name }), "Id", "Name");

            //ViewBag.IncidentRoads = new SelectList((await IncidentRoads()).Select(x => new { Id = x.IncidentRoadId, x.Name }), "Id", "Name");

            ViewBag.IncidentRoads = await IncidentRoads();

            ViewBag.AreaConditions = new SelectList((await AreaConditions()).Select(x => new { Id = x.AreaConditionId, x.Name }), "Id", "Name");

            ViewBag.Weathers = new SelectList((await Weathers()).Select(x => new { Id = x.WeatherId, x.Name }), "Id", "Name");

            ViewBag.Traffics = new SelectList((await Traffics()).Select(x => new { Id = x.TrafficId, x.Name }), "Id", "Name");

            ViewBag.IncidentDepots = await IncidentDepots();

            //var keys = ((await app.UnsafeCategories.AllAsyncAsNoTracking()).Select(x => new UnsafeCategoryDto {
            //    Code = x.UnsafeCategoryCode,
            //    Name = x.Name
            //})).ToList();

            ViewBag.UnsafetyCategories = await UnsafeCategories();
            ViewBag.UnsafeItem = await UnsafeItems();

            ViewBag.Positions = new SelectList((await Positions()).Select(x => new { Id = x.PositionId, x.Name }), "Id", "Name");

            return View();
        }

        public async Task<IActionResult> GetCarrierList() =>
         Json((await app.Carries.AllAsyncAsNoTracking()).Select(x => x.Name).ToArray());

        [HttpPost]
        public async Task<IActionResult> Create(InvestigateCard item, string radioCompany, string radioShift, string radioCase, string radioAccident, string radioTransport, string radioOther, string radioRank, DateTime caseDate, string radioRoute, string radioIsProduct, string radioIsDamage, string radioEffect, string radioEmpInjure, string radioPartiesInjure, string radioThirdParty, string radioTruckDamage, string radioPartyDamage, string radioEquipmentDamage, string radioCamera, string radioIsNormal, string radioIsGps, string radioIsCctv, string radioIsAlcohol, DateTime inspectionDate, string[] description, string[] c100, string[] c200, string[] c300, string[] c400, string[] c500, string[] c600, string[] c700, string[] c800, string[] c900, string[] u00, string[] v00, string radioIsPassSafety, string radioIsPassSDC, string radioIncident, int? radioIncidentRoad, int? radioIncidentDepot, string carreirName) {
            try {
                var guid = Guid.NewGuid();
                #region PartOne
                //assign branchName and regionName
                var branch = await app.Branches.FindAsync(item.PartOne.BranchCode);
                item.PartOne.BranchName = branch.Name;
                item.PartOne.RegionId = branch.RegionId;
                item.PartOne.RegionName = branch.Region.Name;
                item.PartOne.EmployeeCode = "2601-" + item.PartOne.EmployeeCode;

                //assign employee name
                //var emp = await app.Employees.FindAsync(item.PartOne.EmployeeCode);
                //item.PartOne.EmployeeName = emp.NameTH;

                //assign positon name

                //assign plate number
                if (item.PartOne.VehicleId != null) {
                    item.PartOne.PlateNumber = (await app.Vehicles.FindAsync(Convert.ToInt32(item.PartOne.VehicleId))).PlateNumber;
                };

                //assign value from radio button
                if (radioCompany != "on") { item.PartOne.CompanyName = radioCompany; }
                if (radioShift != "on") { item.PartOne.Shift = radioShift; }

                if (item.PartOne.CompanyName == null) {
                    item.PartOne.CompanyName = item.PartOne.CompanyName ?? carreirName;
                    item.PartOne.IsSub = true;
                }

                item.PartOne.CaseType = GetCaseType(radioCase);
                item.PartOne.AccidentMode = GetAccidentMode(radioAccident);
                if (item.PartOne.AccidentMode == AccidentMode.Transport) {
                    item.PartOne.TransportBy = GetTransportBy(radioTransport);
                } else {
                    item.PartOne.OtherBy = GetOtherBy(radioOther);
                }
                item.PartOne.Rank = GetRank(radioRank);
                item.PartOne.CreatedBy = User.Identity.Name;
                item.PartOne.CaseDate = caseDate;
                // item.PartOne.CaseTime = caseTime;

                #endregion

                #region PartTwo
                // item.PartTwo.LeaveBranchTime = leaveBranchTime;
                item.PartTwo.IncidentRoute = GetRoute(radioRoute);
                item.PartTwo.IsProduct = radioIsProduct == "True";
                item.PartTwo.IsProductDamage = radioIsDamage == "True";
                item.PartTwo.CaseEffect = GetEffect(radioEffect);

                item.PartTwo.EmpInjure = GetInjure(radioEmpInjure);
                item.PartTwo.PartiesInjure = GetInjure(radioPartiesInjure);
                item.PartTwo.ThirdPartiesInjure = GetInjure(radioThirdParty);

                item.PartTwo.TruckDamage = GetTruckDamage(radioTruckDamage);
                item.PartTwo.PartiesDamage = GetTruckDamage(radioPartyDamage);
                item.PartTwo.EquipmentDamage = GetTruckDamage(radioEquipmentDamage);
                item.PartTwo.Camera = GetCamera(radioCamera);

                item.PartTwo.IsTruckInspectionNormal = radioIsNormal == "True";
                item.PartTwo.IsGps = radioIsGps == "True";
                item.PartTwo.IsCctv = radioIsCctv == "True";
                item.PartTwo.IsPassSafetyCourse = radioIsPassSafety == "True";
                item.PartTwo.IsPassSDC = radioIsPassSDC == "True";

                item.PartTwo.Training = null; //GetTraining(radioTraining);
                item.PartTwo.IsPassAlcohol = radioIsAlcohol == "True";
                item.PartTwo.LastMaintenanceDate = inspectionDate;
                item.PartTwo.CreatedBy = User.Identity.Name;

                #endregion

                #region PartThree
                //save file to wwwroot/resources/images folder
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "resources", "images");
                await SaveImage(item, uploadFolder, guid);
                #endregion

                #region PartFour
                item.PartFour.CreatedBy = User.Identity.Name;
                item.PartFour.IncidentRoadId = radioIncidentRoad;
                item.PartFour.IncidentDepotId = radioIncidentDepot;
                #endregion

                #region PartFive

                if (c100.Length > 0) {
                    AddPartFiveDetail(item, c100);
                }
                if (c400.Length > 0) {
                    AddPartFiveDetail(item, c400);
                }
                if (c500.Length > 0) {
                    AddPartFiveDetail(item, c500);
                }
                if (c700.Length > 0) {
                    AddPartFiveDetail(item, c700);
                }
                if (c200.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c200, description);
                }
                if (c300.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c300, description);
                }
                if (c600.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c600, description);
                }
                if (c800.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c800, description);
                }
                if (c900.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c900, description);
                }
                if (u00.Length > 0) {
                    AddPartFiveDetail(item, u00);
                }
                if (v00.Length > 0) {
                    AddPartFiveDetail(item, v00);
                }

                item.PartFive.CreatedBy = User.Identity.Name;

                #endregion

                ModelState.Remove("PartOne.RegionName");
                ModelState.Remove("PartOne.BranchName");
                if (ModelState.IsValid) {
                    item.InvestigateCardId = guid;
                    item.CreatedBy = User.Identity.Name;
                    await app.InvestigateCards.AddAsync(item);
                    await app.SaveChangesAsync();

                    return RedirectToAction("OpenPartSix", "PartSixes", new {
                        id = guid,
                        sms = "OpenPartsix",
                        createOrEdit = "create"
                    });

                } else {
                    string message = String.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                    return RedirectToAction(nameof(Index), new { sms = message });

                }
            } catch (Exception ex) {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = message });
            }
        }

        public async Task<IActionResult> Edit(Guid id) {
            try {
                // Guid _id = new Guid(id);
                var model = await app.InvestigateCards.FindAsync(id);
                if (model == null) {
                    return RedirectToAction(nameof(Index), new { sms = "ไม่พบข้อมูลส่วนที่1-5" });
                }

                for (int i = 1; i < 5; i++) {
                    var imgFolder = Path.Combine(webHostEnvironment.WebRootPath, "resources", "images");
                    var fileName = $"{id}_{i}.png";
                    string filePath = Path.Combine(imgFolder, fileName);
                    if (System.IO.File.Exists(filePath)) {
                        byte[] imageByteData = System.IO.File.ReadAllBytes(filePath);
                        string imageBase64Data = Convert.ToBase64String(imageByteData);
                        string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        ViewData[$"Image{i}"] = imageDataURL;
                    }
                }

                ViewBag.Branches = new SelectList((await Branches()).Select(x => new { Id = x.BranchCode, x.Name }), "Id", "Name", model.PartOne.BranchCode);

                //part four
                ViewBag.IncidentRoads = await IncidentRoads();

                ViewBag.IncidentDepots = await IncidentDepots();

                ViewBag.IncidentTrucks = new SelectList((await IncidentTrucks()).Select(x => new { Id = x.IncidentTruckId, x.Name }), "Id", "Name", model.PartFour.IncidentTruckId);

                ViewBag.AreaConditions = new SelectList((await AreaConditions()).Select(x => new { Id = x.AreaConditionId, x.Name }), "Id", "Name", model.PartFour.AreaConditionId);

                ViewBag.IncidentTruckPositons = new SelectList((await IncidentTruckPositons()).Select(x => new { Id = x.IncidentTruckPositonId, x.Name }), "Id", "Name", model.PartFour.IncidentTruckPositonId);

                ViewBag.Weathers = new SelectList((await Weathers()).Select(x => new { Id = x.WeatherId, x.Name }), "Id", "Name", model.PartFour.WeatherId);

                ViewBag.Traffics = new SelectList((await Traffics()).Select(x => new { Id = x.TrafficId, x.Name }), "Id", "Name", model.PartFour.TrafficId);

                ViewBag.IncidentAreas = new SelectList((await IncidentAreas()).Select(x => new { Id = x.IncidentAreaId, x.Name }), "Id", "Name", model.PartFour.IncidentAreaId);

                //
                //part five
                ViewBag.UnsafetyCategories = await UnsafeCategories();
                ViewBag.UnsafeItem = await UnsafeItems();

                //get category item code from part five detail
                ViewBag.UnsafeItems = String.Join(",", model.PartFive.PartFiveDetails.Select(x => x.UnsafeItemCode).ToList());

                ViewBag.AccidentMode = model.PartOne.AccidentMode;

                ViewBag.Positions = new SelectList((await Positions()).Select(x => new { Id = x.PositionId, x.Name }), "Id", "Name");

                if (model.PartOne.EmployeeCode == "2601-") {
                    model.PartOne.EmployeeCode = null;
                } else {
                    model.PartOne.EmployeeCode = model.PartOne.EmployeeCode.Substring(5, 6);
                }

                //case type (ผิดหรือประมาทร่วม)
                ViewBag.CastType = model.PartTwo.TruckDamage.ToString();

                return View(model);

            } catch (Exception ex) {
                var errors = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return RedirectToAction(nameof(Index), new { sms = errors });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InvestigateCard item, string radioCompany, string radioShift, string radioCase, string radioAccident, string radioTransport, string radioOther, string radioRank, DateTime caseDate, string radioRoute, string radioIsProduct, string radioIsDamage, string radioEffect, string radioEmpInjure, string radioPartiesInjure, string radioThirdParty, string radioTruckDamage, string radioPartyDamage, string radioEquipmentDamage, string radioCamera, string radioIsNormal, string radioIsGps, string radioIsCctv, string radioIsAlcohol, DateTime inspectionDate, string[] description, string[] c100, string[] c200, string[] c300, string[] c400, string[] c500, string[] c600, string[] c700, string[] c800, string[] c900, string[] u00, string[] v00, string radioIsPassSafety, string radioIsPassSDC, string radioIncident, int? radioIncidentRoad, int? radioIncidentDepot, string carreirName, int previousDamage) {

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try {

                #region Delete Before Add New
                //1 delete penalty card
                var _penalty = (await app.PenaltyNotices.QueryAsyncAsNoTracking(x => x.InvestigateCardId == item.InvestigateCardId)).FirstOrDefault();
                var penaltyCode = _penalty?.PenaltyNoticeCode;
                if (!String.IsNullOrWhiteSpace(penaltyCode)) {
                    var penalty = await app.PenaltyNotices.FindAsync(penaltyCode);
                    await app.PenaltyNotices.RemoveAsync(penalty);
                }

                //2 delete old part one before add new
                var pone = (await app.PartOnes.QueryAsyncAsNoTracking(x => x.InvestigateCardId == item.InvestigateCardId)).FirstOrDefault();
                var poneId = pone?.PartOneId;
                if (poneId != null) {
                    var partone = await app.PartOnes.FindAsync(poneId);
                    await app.PartOnes.RemoveAsync(partone);
                }

                var ptwo = (await app.PartTwos.QueryAsyncAsNoTracking(x => x.InvestigateCardId == item.InvestigateCardId)).FirstOrDefault();
                var ptwoId = ptwo?.PartTwoId;
                if (ptwoId != null) {
                    var parttwo = await app.PartTwos.FindAsync(ptwoId);
                    await app.PartTwos.RemoveAsync(parttwo);
                }

                //3 delete old part three before add new
                var pthree = (await app.PartThrees.QueryAsyncAsNoTracking(x => x.InvestigateCardId == item.InvestigateCardId)).FirstOrDefault();
                var pthreeId = pthree?.PartThreeId;
                if (pthreeId != null) {
                    var partthree = await app.PartThrees.FindAsync(pthreeId);
                    await app.PartThrees.RemoveAsync(partthree);
                }

                //4 delete old part four before add new
                var pfour = (await app.PartFours.QueryAsyncAsNoTracking(x => x.InvestigateCardId == item.InvestigateCardId)).FirstOrDefault();
                var pfourId = pfour?.PartFourId;
                if (pfourId != null) {
                    var partfour = await app.PartFours.FindAsync(pfourId);
                    await app.PartFours.RemoveAsync(partfour);
                }

                //5 delete old part five before add new
                var pfive = (await app.PartFives.QueryAsyncAsNoTracking(x => x.InvestigateCardId == item.InvestigateCardId)).FirstOrDefault();
                var pfiveId = pfive?.PartFiveId;
                if (pfiveId != null) {
                    var partfive = await app.PartFives.FindAsync(pfiveId);
                    foreach (var detail in partfive.PartFiveDetails) {
                        var _detail = await app.PartFiveDetails.FindAsync(detail.PartFiveDetailId);
                        await app.PartFiveDetails.RemoveAsync(_detail);
                    }
                    await app.PartFives.RemoveAsync(partfive);
                }

                //6 delete old part six before add new
                var psix = (await app.PartSixs.QueryAsyncAsNoTracking(x => x.InvestigateCardId == item.InvestigateCardId));
                if (psix.Count() > 0) {
                    foreach (var _psix in psix) {
                        var psixItem = await app.PartSixs.FindAsync(_psix.PartSixId);
                        await app.PartSixs.RemoveAsync(psixItem);
                    }
                }
                #endregion

                #region PartOne
                //assign branchName and regionName
                var branch = await app.Branches.FindAsync(item.PartOne.BranchCode);
                item.PartOne.BranchName = branch.Name;
                item.PartOne.RegionId = branch.RegionId;
                item.PartOne.RegionName = branch.Region.Name;
                item.PartOne.EmployeeCode = "2601-" + item.PartOne.EmployeeCode;


                item.PartOne.CreatedBy = User.Identity.Name;
                item.PartOne.Modified = DateTime.Now;
                item.PartOne.ModifiedBy = User.Identity.Name;

                //assign plate number
                if (item.PartOne.VehicleId != null) {
                    item.PartOne.PlateNumber = (await app.Vehicles.FindAsync(Convert.ToInt32(item.PartOne.VehicleId))).PlateNumber;
                };

                //assign value from radio button
                if (radioCompany != "on") { item.PartOne.CompanyName = radioCompany; }
                if (radioShift != "on") { item.PartOne.Shift = radioShift; }
                if (item.PartOne.CompanyName == null) {
                    item.PartOne.CompanyName = item.PartOne.CompanyName ?? carreirName;
                    item.PartOne.IsSub = true;
                }

                item.PartOne.CaseType = GetCaseType(radioCase);
                item.PartOne.AccidentMode = GetAccidentMode(radioAccident);
                if (item.PartOne.AccidentMode == AccidentMode.Transport) {
                    item.PartOne.TransportBy = GetTransportBy(radioTransport);
                } else {
                    item.PartOne.OtherBy = GetOtherBy(radioOther);
                }
                item.PartOne.Rank = GetRank(radioRank);
                item.PartOne.CaseDate = caseDate;

                #endregion

                #region PartTwo
                item.PartTwo.IncidentRoute = GetRoute(radioRoute);
                item.PartTwo.IsProduct = radioIsProduct == "True";
                item.PartTwo.IsProductDamage = radioIsDamage == "True";
                item.PartTwo.CaseEffect = GetEffect(radioEffect);

                item.PartTwo.EmpInjure = GetInjure(radioEmpInjure);
                item.PartTwo.PartiesInjure = GetInjure(radioPartiesInjure);
                item.PartTwo.ThirdPartiesInjure = GetInjure(radioThirdParty);

                item.PartTwo.TruckDamage = GetTruckDamage(radioTruckDamage);
                item.PartTwo.PartiesDamage = GetTruckDamage(radioPartyDamage);
                item.PartTwo.EquipmentDamage = GetTruckDamage(radioEquipmentDamage);
                item.PartTwo.Camera = GetCamera(radioCamera);

                item.PartTwo.IsTruckInspectionNormal = radioIsNormal == "True";
                item.PartTwo.IsGps = radioIsGps == "True";
                item.PartTwo.IsCctv = radioIsCctv == "True";
                item.PartTwo.IsPassSafetyCourse = radioIsPassSafety == "True";
                item.PartTwo.IsPassSDC = radioIsPassSDC == "True";

                item.PartTwo.Training = null; //GetTraining(radioTraining);
                item.PartTwo.IsPassAlcohol = radioIsAlcohol == "True";
                item.PartTwo.LastMaintenanceDate = inspectionDate;

                item.PartTwo.ModifiedBy = User.Identity.Name;
                item.PartTwo.Modified = DateTime.Now;
                #endregion

                #region PartThree
                //save file to wwwroot/resources/images folder
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "resources", "images");
                await SaveImage(item, uploadFolder, item.InvestigateCardId);
                #endregion

                #region PartFour
                item.PartFour.IncidentRoadId = radioIncidentRoad;
                item.PartFour.IncidentDepotId = radioIncidentDepot;

                item.Modified = DateTime.Now;
                item.ModifiedBy = User.Identity.Name;

                #endregion

                #region PartFive

                if (c100.Length > 0) {
                    AddPartFiveDetail(item, c100);
                }
                if (c400.Length > 0) {
                    AddPartFiveDetail(item, c400);
                }
                if (c500.Length > 0) {
                    AddPartFiveDetail(item, c500);
                }
                if (c700.Length > 0) {
                    AddPartFiveDetail(item, c700);
                }
                if (c200.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c200, description);
                }
                if (c300.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c300, description);
                }
                if (c600.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c600, description);
                }
                if (c800.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c800, description);
                }
                if (c900.Length > 0) {
                    AddPartFiveDetailWithDesc(item, c900, description);
                }
                if (u00.Length > 0) {
                    AddPartFiveDetail(item, u00);
                }
                if (v00.Length > 0) {
                    AddPartFiveDetail(item, v00);
                }

                item.PartFive.CreatedBy = User.Identity.Name;
                item.PartFive.Modified = DateTime.Now;
                item.PartFive.ModifiedBy = User.Identity.Name;

                #endregion

                ModelState.Remove("PartOne.RegionName");
                ModelState.Remove("PartOne.BranchName");
                if (ModelState.IsValid) {
                    item.ModifiedBy = User.Identity.Name;
                    item.Modified = DateTime.Now;
                    item.InvestigateStatusCode = "100";
                    await app.InvestigateCards.UpdateAsync(item);

                    await app.SaveChangesAsync();

                    scope.Complete();

                    return RedirectToAction("OpenPartSix", "PartSixes", new {
                        id = item.InvestigateCardId,
                        sms = "OpenPartsix",
                        createOrEdit = "edit",
                        previousDamage
                    });

                } else {
                    string message = String.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                    return RedirectToAction(nameof(Index), new { sms = message });
                }

            } catch (DbUpdateConcurrencyException) {
                var isExists = await InvestigateExists(item.InvestigateCardId);
                if (!isExists) {
                    return RedirectToAction(nameof(Index), new { sms = "Item not found." });
                }
            } catch (Exception ex) {
                string errors = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return RedirectToAction(nameof(Index), new { sms = errors });
            }

            return View();
        }

        private async Task<bool> InvestigateExists(Guid id) {
            return await app.InvestigateCards.AnyAsync(x => x.InvestigateCardId == id);
        }

        private void AddPartFiveDetailWithDesc(InvestigateCard item, string[] arrParam, string[] description) {
            for (int i = 0; i < arrParam.Length; i++) {
                string[] words = arrParam[i].Split('_');
                var unsafeCategoryCode = words[0];
                var unsafeItemCode = words[1];
                var detail = new PartFiveDetail {
                    UnsafeCategoryCode = unsafeCategoryCode,
                    UnsafeItemCode = unsafeItemCode,
                    CreatedBy = User.Identity.Name,
                    Description = unsafeItemCode switch {
                        "216" => description[0],
                        "311" => description[1],
                        "619" => description[2],
                        "808" => description[3],
                        "813" => description[4],
                        "915" => description[5],
                        _ => null,
                    }
                };
                item.PartFive.AddDetail(detail, User.Identity.Name);
            }
        }

        private void AddPartFiveDetail(InvestigateCard item, string[] arrParam) {
            for (int i = 0; i < arrParam.Length; i++) {
                string[] words = arrParam[i].Split('_');
                var detail = new PartFiveDetail() {
                    UnsafeCategoryCode = words[0],
                    UnsafeItemCode = words[1],
                    CreatedBy = User.Identity.Name
                };

                item.PartFive.AddDetail(detail, User.Identity.Name);
            }
        }

        private async Task SaveImage(InvestigateCard item, string uploadFolder, Guid guid) {

            if (item.PartThree.ImageBeforeIncidenName != null) {
                if (item.PartThree.ImageBeforeIncidenFile != null) {
                    var contentType = Array.Find(imagetype, x => x.Contains(item.PartThree.ImageBeforeIncidenFile.ContentType));
                    if (contentType == null) throw new Exception("Image1 incorrect content type.");

                    string filePath = Path.Combine(uploadFolder, $"{guid}_1.png");

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await item.PartThree.ImageBeforeIncidenFile.CopyToAsync(stream);
                    item.PartThree.ImageBeforeIncidenName = $"{guid}_1.png";
                }
            }
            if (item.PartThree.ImageIncidentName != null) {
                if (item.PartThree.ImageIncidenFile != null) {
                    var contentType = Array.Find(imagetype, x => x.Contains(item.PartThree.ImageIncidenFile.ContentType));

                    if (contentType == null) throw new Exception("Image2 incorrect content type.");

                    string filePath = Path.Combine(uploadFolder, $"{guid}_2.png");
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await item.PartThree.ImageIncidenFile.CopyToAsync(stream);
                    item.PartThree.ImageIncidentName = $"{guid}_2.png";
                }
            }
            if (item.PartThree.ImageAfterIncidentName != null) {
                if (item.PartThree.ImageAfterIncidenFile != null) {

                    var contentType = Array.Find(imagetype, x => x.Contains(item.PartThree.ImageAfterIncidenFile.ContentType));

                    if (contentType == null) throw new Exception("Image3 incorrect content type.");

                    string filePath = Path.Combine(uploadFolder, $"{guid}_3.png");
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await item.PartThree.ImageAfterIncidenFile.CopyToAsync(stream);
                    item.PartThree.ImageAfterIncidentName = $"{guid}_3.png";
                }
            }
            if (item.PartThree.ImageIncidentAreaName != null) {
                if (item.PartThree.ImageIncidentAreaFile != null) {
                    var contentType = Array.Find(imagetype, x => x.Contains(item.PartThree.ImageIncidentAreaFile.ContentType));

                    if (contentType == null) throw new Exception("Image4 incorrect content type.");

                    string filePath = Path.Combine(uploadFolder, $"{guid}_4.png");
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await item.PartThree.ImageIncidentAreaFile.CopyToAsync(stream);
                    item.PartThree.ImageIncidentAreaName = $"{guid}_4.png";
                }
            }

        }

        private CaseTraining GetTraining(string radioTraining) {
            return radioTraining switch {
                "ความปลอดภัยผ่าน" => CaseTraining.ความปลอดภัยผ่าน,
                "SDCผ่าน" => CaseTraining.SDCผ่าน,
                _ => throw new ArgumentException("Invalid radioTraining value")
            };
        }

        private CaseCamera GetCamera(string radioCamera) {
            return radioCamera switch {
                "บันทึกปกติใช้งานได้" => CaseCamera.บันทึกปกติใช้งานได้,
                "ไม่บันทึกกล้องเสีย" => CaseCamera.ไม่บันทึกกล้องเสีย,
                "ไม่มีกล้อง" => CaseCamera.ไม่มีกล้อง,
                _ => throw new ArgumentException("Invalid radioTruckDamage value")
            };
        }

        private CaseDamage GetTruckDamage(string radioTruckDamage) {
            return radioTruckDamage switch {
                "ไม่ได้รับความเสียหาย" => CaseDamage.ไม่ได้รับความเสียหาย,
                "ได้รับความเสียหายกรณีเป็นฝ่ายผิดแจ้งหักเงิน" => CaseDamage.ได้รับความเสียหายกรณีเป็นฝ่ายผิดแจ้งหักเงิน,
                "ได้รับความเสียหาย" => CaseDamage.ได้รับความเสียหาย,
                _ => throw new ArgumentException("Invalid radioTruckDamage value")
            };
        }

        private CaseInjure GetInjure(string radioInjure) {
            return radioInjure switch {
                "ไม่ได้รับบาดเจ็บ" => CaseInjure.ไม่ได้รับบาดเจ็บ,
                "ได้รับบาดเจ็บ" => CaseInjure.ได้รับบาดเจ็บ,
                "หยุดงาน" => CaseInjure.หยุดงาน,
                "เสียชีวิต" => CaseInjure.เสียชีวิต,
                _ => throw new ArgumentException("Invalid radioEmpInjure value")
            };
        }

        private CaseEffect GetEffect(string radioEffect) {
            return radioEffect switch {
                "สามารถส่งต่อได้หลังเกิดเหตุ" => CaseEffect.สามารถส่งต่อได้หลังเกิดเหตุ,
                "พัสดุเลื่อนส่ง" => CaseEffect.พัสดุเลื่อนส่ง,
                _ => throw new ArgumentException("Invalid radioRoute value")
            };
        }

        private IncidentRoute GetRoute(string radioRoute) {
            return radioRoute switch {
                "วิ่งประจำ" => IncidentRoute.วิ่งประจำ,
                "เปลี่ยนเส้นทางวิ่งชั่วคราว" => IncidentRoute.เปลี่ยนเส้นทางวิ่งชั่วคราว,
                _ => throw new ArgumentException("Invalid radioRoute value")

            };
        }

        private Rank GetRank(string radioRank) {
            return radioRank switch {
                "L0เล็กน้อยไม่เข้าเกณฑ์เฉี่ยวชนเล็กน้อยไม่มีคนบาดเจ็บ" => Rank.L0เล็กน้อยไม่เข้าเกณฑ์เฉี่ยวชนเล็กน้อยไม่มีคนบาดเจ็บ,
                "L1ขั้นปฐมพยาบาลรถใช้งานต่อไปได้" => Rank.L1ขั้นปฐมพยาบาลรถใช้งานต่อไปได้,
                "L2ขั้นรักษาพยาบาลเปลี่ยนงานไม่หยุดงานรถถูกลาก" => Rank.L2ขั้นรักษาพยาบาลเปลี่ยนงานไม่หยุดงานรถถูกลาก,
                "L3หยุดงานรถไม่สามารถซ่อมได้คืนซากรถ" => Rank.L3หยุดงานรถไม่สามารถซ่อมได้คืนซากรถ,
                "L3เสียชีวิตรถไม่สามารถซ่อมได้คืนซากรถ" => Rank.L3เสียชีวิตรถไม่สามารถซ่อมได้คืนซากรถ,
                _ => throw new ArgumentException("Invalid radioRank value")
            };
        }

        private OtherBy GetOtherBy(string radioOther) {
            return radioOther switch {
                "อุบัติเหตุในคลังหรือสาขา" => OtherBy.อุบัติเหตุในคลังหรือสาขา,
                "อุบัติเหตุในสำนักงานออฟฟิต" => OtherBy.อุบัติเหตุในสำนักงานออฟฟิต,
                _ => throw new ArgumentException("Invalid radioOther value")
            };
        }

        private TransportBy GetTransportBy(string radioTransport) {
            return radioTransport switch {
                "รถกระบะติดตั้งตู้" => TransportBy.รถกระบะติดตั้งตู้,
                "รถจักรยานยนต์" => TransportBy.รถจักรยานยนต์,
                "รถเก๋ง" => TransportBy.รถเก๋ง,
                _ => throw new ArgumentException("Invalid radioTransport value")
            };
        }

        private AccidentMode GetAccidentMode(string radioAccident) {
            return radioAccident switch {
                "Transport" => AccidentMode.Transport,
                "Other" => AccidentMode.Other,
                _ => throw new ArgumentException("Invalid radioAccident value")
            };
        }

        private CaseType GetCaseType(string radioCase) {
            return radioCase switch {
                "ถูก" => CaseType.ถูก,
                "ผิด" => CaseType.ผิด,
                "ประมาทร่วม" => CaseType.ประมาทร่วม,
                _ => throw new ArgumentException("Invalid radioCase value"),
            };
        }

        public async Task<IActionResult> GetPosition(string id) => Json((await app.Employees.FindAsync(id)).Position);

        [HttpPost]
        public async Task<JsonResult> AddVehicle(string plateNumber, int regionId, string branchCode, string gps, string brand, string vehicleType) {
            try {
                string regionName = (await app.Regions.FindAsync(regionId)).Name;
                Vehicle vehicle = new Vehicle();
                vehicle.PlateNumber = plateNumber;
                vehicle.BranchCode = branchCode;
                vehicle.Brand = brand;
                vehicle.GpsProvider = gps;
                vehicle.RegionId = regionId;
                vehicle.RegionName = regionName;
                vehicle.VehicleType = vehicleType == "pickup" ? VehicleType.Pickup : VehicleType.Motorcycle;
                vehicle.CreatedBy = User.Identity.Name;

                await app.Vehicles.AddAsync(vehicle);
                await app.SaveChangesAsync();
                // var vehicleId = vehicle.Id;

                var jsondata = new {
                    Message = "Successfully",
                    PlateNumber = vehicle.PlateNumber,
                    VehicleId = vehicle.Id,
                    Error = "",
                };

                return Json(jsondata);

            } catch (Exception ex) {
                string error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var jsondata = new {
                    Message = "Error",
                    Error = error
                };

                return Json(jsondata);
            }

        }

        [HttpPost]
        public async Task<JsonResult> AddEmployee(string employeeName, string position) {
            try {
                Employee employee = new Employee();
                employee.EmployeeCode = await app.Employees.GenCode();
                employee.NameTH = employeeName;
                employee.NameEN = employeeName;
                employee.Position = position;

                await app.Employees.AddAsync(employee);
                await app.SaveChangesAsync();

                var jsondata = new {
                    Message = "Successfully",
                    EmployeeName = employee.NameTH,
                    EmployeeCode = employee.EmployeeCode,
                    Error = "",
                };

                return Json(jsondata);

            } catch (Exception ex) {
                string error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var jsondata = new {
                    Message = "Error",
                    Error = error
                };

                return Json(jsondata);
            }

        }

        [HttpGet]
        public IActionResult RemoveImage(string id) {
            try {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "resources", "images");
                string filePath = Path.Combine(uploadFolder, $"{id}");

                if (System.IO.File.Exists(filePath)) {
                    System.IO.File.Delete(filePath);
                    var result = new {
                        Message = "Successfully",
                        Error = ""
                    };

                    return Json(result);

                } else {
                    var result = new {
                        Message = "ImageNotFound",
                        Error = ""
                    };

                    return Json(result);
                }

            } catch (Exception ex) {
                string error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var result = new {
                    Message = "Error",
                    Error = error
                };

                return Json(result);
            }
        }
    }
}
