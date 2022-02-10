using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models.ViewModels {
   public class DailyBranchDistanceViewModel {
        public string RegionName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string PlateNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public int StartOdometer { get; set; }
        public int FinishedOdometer { get; set; }
        public int TotalOdometer { get; set; }
    }
}
