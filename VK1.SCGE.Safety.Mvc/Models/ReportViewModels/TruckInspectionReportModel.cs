using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Models.ReportViewModels {
    public class TruckInspectionReportModel {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public List<TruckInspectionReportBranch> Branches { get; set; }
    }

    public class TruckInspectionReportBranch {
        public int RegionId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public List<TruckInspectionReortVehicle> Vehicles { get; set; }
    }

    public class TruckInspectionReortVehicle {
        public string BranchCode { get; set; }
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; }
        public List<TruckInspectionReportItem> Items { get; set; }
    }

    public class TruckInspectionReportItem {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
