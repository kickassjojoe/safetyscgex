using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class Parcel {
        public int Id { get; set; }
        public string Type { get; set; }
        public string RegionName { get; set; }
        public int Month { get; set; }
        public DateTime Date { get; set; }
        public int NewCustomerQty { get; set; }
        public int OldCustomerQty { get; set; }
        public int NewOrderQty { get; set; }
        public int OldOrderQty { get; set; }

    }
}

