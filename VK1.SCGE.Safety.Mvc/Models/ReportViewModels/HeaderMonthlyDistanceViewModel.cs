using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Models.ReportViewModels {
    public class HeaderMonthly {
        public string RegionName { get; set; }
        public List<ItemMonthly> Items { get; set; }
    }

    public class ItemMonthly {
        public string RegionName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int PickupKm { get; set; }
        public int MotorcycleKm { get; set; }
        public int SubContactKm { get; set; }
    }
}
