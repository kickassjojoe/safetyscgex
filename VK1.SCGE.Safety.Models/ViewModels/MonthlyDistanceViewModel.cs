using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models.ViewModels {
   public class MonthlyDistanceViewModel {
        public int Years { get; set; }
        public int Months { get; set; }
        public string RegionName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int PickupKm { get; set; }
        public int MotocycleKm { get; set; }
        public int SubContactKm { get; set; }

    }
}
