using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Function.ViewModels {
   public class CorrectiveActionRequestDto {
        //public string CARCode { get; set; }
        //public DateTime Created { get; set; }
        //public string CreatedBy { get; set; }
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        //public string CARStatusCode { get; set; }
        //public string CARStatusName { get; set; }
    }
}
