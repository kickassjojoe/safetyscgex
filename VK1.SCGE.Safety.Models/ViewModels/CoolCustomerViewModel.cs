using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models.ViewModels {
    public class CoolCustomerViewModel {
        public string RegionName { get; set; }
        public string Month { get; set; }
        public DateTime Date { get; set; }
        public decimal OldCustomerQty { get; set; }
        public decimal NewCustomerQty { get; set; }
        public decimal OldOrderQty { get; set; }
        public decimal NewOrderQty { get; set; }
        public string Type { get; set; }
    }
}
