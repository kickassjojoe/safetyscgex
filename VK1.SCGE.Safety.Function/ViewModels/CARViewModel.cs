using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace VK1.SCGE.Safety.Function.ViewModels {
   public class CARViewModel {
        public int TruckInspectionCardDetailId { get; set; }
        public string PlateNumber { get; set; }
        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int TruckInspectionCategoryId { get; set; }
        public string Category { get; set; }
        public int TruckInspectionItemId { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
    }
}
