using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace VK1.SCGE.Safety.Models.ViewModels {
   public class TruckInspectionReportViewModel {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; }
        public bool IsNormal { get; set; }
        public int TruckInspectionItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
