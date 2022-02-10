using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc.Dtos {
    public class TruckInspectionCardResponse {
        public int TruckInspectionCardId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int StartOdometer { get; set; }
    }
}
