using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Data;

namespace VK1.SCGE.Safety.Services {
    public class App {
        internal readonly AppDb db;

        private Func<DateTime> _now = () => DateTime.Now;
        public Func<DateTime> Now {
            get => _now;
            private set => _now = value;
        }

        //fields
        private readonly Lazy<EmployeeService> _employees;
        private readonly Lazy<TruckInspectionCategoryService> _truckInspectionCategories;
        private readonly Lazy<TruckInspectionItemService> _truckInspectionItems;
        private readonly Lazy<BranchService> _branches;
        private readonly Lazy<VehicleService> _vehicles;
        private readonly Lazy<TruckInspectionCardService> _truckInspectionCards;
        private readonly Lazy<RegionService> _regions;
        private readonly Lazy<LogNumberService> _lognumbers;
        private readonly Lazy<CARService> _car;
        private readonly Lazy<CARItemService> _carItems;
        private readonly Lazy<CARStatusService> _carStatuses;
        private readonly Lazy<TruckInspectionCardDetailService> _truckInspectionCardDetails;
        private readonly Lazy<SubContactService> _subContacts;
        private readonly Lazy<CardControlService> _cardControls;
        private readonly Lazy<InvestigateCardService> _investigateCards;
        private readonly Lazy<PartOneService> _partones;
        private readonly Lazy<PartTwoService> _parttwos;
        private readonly Lazy<PartThreeService> _partthrees;
        private readonly Lazy<PartFourService> _partFours;
        private readonly Lazy<PartFiveService> _partFives;
        private readonly Lazy<PartSixService> _partSixs;

        private readonly Lazy<IncidentTruckSerivce> _incidentTrucks;
        private readonly Lazy<IncidentTruckPositonService> _incidentTruckPositons;
        private readonly Lazy<IncidentAreaService> _incidentAreas;
        private readonly Lazy<IncidentRoadService> _incidentRoads;
        private readonly Lazy<AreaConditionService> _areaConditions;
        private readonly Lazy<WeatherService> _weathers;
        private readonly Lazy<TrafficService> _traffics;
        private readonly Lazy<IncidentDepotService> _incidentDepots;
        private readonly Lazy<UnsafeCategoryService> _unsafeCategories;
        private readonly Lazy<PartFiveDetailService> _partFiveDetails;
        private readonly Lazy<UnsafeItemService> _unsafeItems;
        private readonly Lazy<LogEmployeeAccidentService> _logEmployees;
        private readonly Lazy<DeductPointService> _deductpoints;
        private readonly Lazy<PenaltyNoticeService> _penalties;
        private readonly Lazy<PenaltyNoticeDetailService> _penaltyDetails;
        private readonly Lazy<PositionService> _positions;
        private readonly Lazy<CarrierService> _carriers;

        private readonly Lazy<ParcelService> _parcels;

        public App() {
            //
        }
        public App(AppDb db) {
            this.db = db;

            _employees = new Lazy<EmployeeService>(() => new EmployeeService(this));
            _truckInspectionCategories = new Lazy<TruckInspectionCategoryService>(() => new TruckInspectionCategoryService(this));
            _truckInspectionItems = new Lazy<TruckInspectionItemService>(() => new TruckInspectionItemService(this));
            _branches = new Lazy<BranchService>(() => new BranchService(this));
            _vehicles = new Lazy<VehicleService>(() => new VehicleService(this));
            _truckInspectionCards = new Lazy<TruckInspectionCardService>(() => new TruckInspectionCardService(this));
            _regions = new Lazy<RegionService>(() => new RegionService(this));
            _lognumbers = new Lazy<LogNumberService>(() => new LogNumberService(this));
            _car = new Lazy<CARService>(() => new CARService(this));
            _carItems = new Lazy<CARItemService>(() => new CARItemService(this));
            _carStatuses = new Lazy<CARStatusService>(() => new CARStatusService(this));
            _truckInspectionCardDetails = new Lazy<TruckInspectionCardDetailService>(() => new TruckInspectionCardDetailService(this));
            _subContacts = new Lazy<SubContactService>(() => new SubContactService(this));
            _cardControls = new Lazy<CardControlService>(() => new CardControlService(this));
            _investigateCards = new Lazy<InvestigateCardService>(() => new InvestigateCardService(this));
            _partones = new Lazy<PartOneService>(() => new PartOneService(this));
            _parttwos = new Lazy<PartTwoService>(() => new PartTwoService(this));
            _partthrees = new Lazy<PartThreeService>(() => new PartThreeService(this));
            _partFours = new Lazy<PartFourService>(() => new PartFourService(this));
            _partFives = new Lazy<PartFiveService>(() => new PartFiveService(this));
            _partSixs = new Lazy<PartSixService>(() => new PartSixService(this));

            _incidentTrucks = new Lazy<IncidentTruckSerivce>(() => new IncidentTruckSerivce(this));
            _incidentTruckPositons = new Lazy<IncidentTruckPositonService>(() => new IncidentTruckPositonService(this));
            _incidentAreas = new Lazy<IncidentAreaService>(() => new IncidentAreaService(this));
            _incidentRoads = new Lazy<IncidentRoadService>(() => new IncidentRoadService(this));
            _areaConditions = new Lazy<AreaConditionService>(() => new AreaConditionService(this));
            _weathers = new Lazy<WeatherService>(() => new WeatherService(this));
            _traffics = new Lazy<TrafficService>(() => new TrafficService(this));
            _incidentDepots = new Lazy<IncidentDepotService>(() => new IncidentDepotService(this));
            _unsafeCategories = new Lazy<UnsafeCategoryService>(() => new UnsafeCategoryService(this));
            _partFiveDetails = new Lazy<PartFiveDetailService>(() => new PartFiveDetailService(this));
            _unsafeItems = new Lazy<UnsafeItemService>(() => new UnsafeItemService(this));
            _logEmployees = new Lazy<LogEmployeeAccidentService>(() => new LogEmployeeAccidentService(this));
            _deductpoints = new Lazy<DeductPointService>(() => new DeductPointService(this));
            _penalties = new Lazy<PenaltyNoticeService>(() => new PenaltyNoticeService(this));
            _penaltyDetails = new Lazy<PenaltyNoticeDetailService>(() => new PenaltyNoticeDetailService(this));
            _positions = new Lazy<PositionService>(() => new PositionService(this));
            _carriers = new Lazy<CarrierService>(() => new CarrierService(this));
            _parcels = new Lazy<ParcelService>(() => new ParcelService(this));

        }

        //properties  publick get private set
        public EmployeeService Employees => _employees.Value;
        public TruckInspectionCategoryService TruckInspectionCategories => _truckInspectionCategories.Value;
        public TruckInspectionItemService TruckInspectionItems => _truckInspectionItems.Value;
        public BranchService Branches => _branches.Value;
        public VehicleService Vehicles => _vehicles.Value;
        public TruckInspectionCardService TruckInspectionCards => _truckInspectionCards.Value;
        public RegionService Regions => _regions.Value;
        public LogNumberService LogNumbers => _lognumbers.Value;
        public CARService CAR => _car.Value;
        public CARItemService CARItem => _carItems.Value;
        public CARStatusService CARStatuses => _carStatuses.Value;
        public TruckInspectionCardDetailService TruckInspectionCardDetails => _truckInspectionCardDetails.Value;
        public SubContactService SubContacts => _subContacts.Value;
        public CardControlService CardControls => _cardControls.Value;
        public InvestigateCardService InvestigateCards => _investigateCards.Value;
        public PartOneService PartOnes => _partones.Value;
        public PartTwoService PartTwos => _parttwos.Value;
        public PartThreeService PartThrees => _partthrees.Value;
        public PartFourService PartFours => _partFours.Value;
        public PartFiveService PartFives => _partFives.Value;
        public PartSixService PartSixs => _partSixs.Value;

        public IncidentTruckSerivce IncidentTrucks => _incidentTrucks.Value;
        public IncidentTruckPositonService IncidentTruckPositons => _incidentTruckPositons.Value;
        public IncidentAreaService IncidentAreas => _incidentAreas.Value;
        public IncidentRoadService IncidentRoads => _incidentRoads.Value;
        public AreaConditionService AreaConditions => _areaConditions.Value;
        public WeatherService Weathers => _weathers.Value;
        public TrafficService Traffics => _traffics.Value;
        public IncidentDepotService IncidentDepots => _incidentDepots.Value;
        public UnsafeCategoryService UnsafeCategories => _unsafeCategories.Value;
        public PartFiveDetailService PartFiveDetails => _partFiveDetails.Value;
        public UnsafeItemService UnsafeItems => _unsafeItems.Value;
        public LogEmployeeAccidentService LogEmployees => _logEmployees.Value;
        public DeductPointService DeductPoints => _deductpoints.Value;
        public PenaltyNoticeService PenaltyNotices => _penalties.Value;
        public PenaltyNoticeDetailService PenaltyNoticeDetails => _penaltyDetails.Value;
        public ParcelService Parcels => _parcels.Value;
        public PositionService Positoins => _positions.Value;
        public CarrierService Carries => _carriers.Value;

        // Save change
        public int SaveChanges() => db.SaveChanges();
        public Task<int> SaveChangesAsync() => db.SaveChangesAsync();
        public async Task<int> ExecuteToSqlAsync(string sql) => await db.Database.ExecuteSqlRawAsync(sql);

        //
        public void SetNow(DateTime dtNow) => Now = () => dtNow;
        public void ResetNow() => Now = () => DateTime.Now;


    }
}
